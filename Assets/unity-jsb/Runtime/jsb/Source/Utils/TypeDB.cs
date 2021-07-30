using System;
using System.Collections.Generic;
using QuickJS.Native;
using QuickJS.Binding;
using System.Reflection;

namespace QuickJS.Utils
{
    public class TypeDB
    {
        private ScriptRuntime _runtime;
        private ScriptContext _context;
        private Dictionary<Type, MethodInfo> _delegates = new Dictionary<Type, MethodInfo>(); // 委托对应的 js 绑定函数
        private Dictionary<Type, int> _typeIndex = new Dictionary<Type, int>();
        private Dictionary<Type, DynamicType> _dynamicTypes = new Dictionary<Type, DynamicType>();
        private List<Type> _types = new List<Type>(); // 可用 索引 反查 Type
        private Dictionary<Type, JSValue> _prototypes = new Dictionary<Type, JSValue>();
        private List<IDynamicMethod> _dynamicMethods = new List<IDynamicMethod>();
        private List<IDynamicField> _dynamicFields = new List<IDynamicField>();

        public int Count
        {
            get { return _types.Count; }
        }

        public TypeDB(ScriptRuntime runtime, ScriptContext context)
        {
            _runtime = runtime;
            _context = context;
        }

        // 获取指定类型的动态绑定 (此方法仅用于用户运行时, 不适用于 RefectBind)
        public DynamicType GetDynamicType(Type type, bool privateAccess)
        {
            DynamicType dynamicType;
            if (_dynamicTypes.TryGetValue(type, out dynamicType))
            {
                if (privateAccess)
                {
                    dynamicType.OpenPrivateAccess();
                }
                return dynamicType;
            }

            var register = _context.CreateTypeRegister();

            dynamicType = new DynamicType(type, privateAccess);
            dynamicType.Bind(register);
            _dynamicTypes[type] = dynamicType;

            register.Finish();
            return dynamicType;
        }

        // //TODO: 用于在动态类型注册过程中产生的关联类型注册
        // public DynamicType RegisterDynamicType(TypeRegister register, Type type)
        // {
        //     DynamicType dynamicType;
        //     if (_dynamicTypes.TryGetValue(type, out dynamicType))
        //     {
        //         return dynamicType;
        //     }

        //     dynamicType = new DynamicType(type, false);
        //     dynamicType.Bind(register);
        //     _dynamicTypes[type] = dynamicType;
        //     return dynamicType;
        // }

        /// <summary>
        /// 创建一个动态绑定类型对象 (不自动执行任何绑定)
        /// </summary>
        public DynamicType CreateFreeDynamicType(Type type)
        {
            DynamicType dynamicType;
            if (_dynamicTypes.TryGetValue(type, out dynamicType))
            {
                return dynamicType;
            }

            dynamicType = new DynamicType(type, false);
            _dynamicTypes[type] = dynamicType;
            return dynamicType;
        }

        // public Module.ModuleExportsBind GetDynamicTypeBind(Type type, bool crossbind)
        // {
        //     return register =>
        //     {
        //         var dynamicType = new DynamicType(type, false);
        //         var cls = dynamicType.Bind(register, crossbind);
        //         _dynamicTypes[type] = dynamicType;
        //         return cls;
        //     };
        // }

        public void AddDelegate(Type type, MethodInfo method)
        {
            _delegates[type] = method;
        }

        public MethodInfo GetDelegateFunc(Type delegateType)
        {
            MethodInfo method;
            if (_delegates.TryGetValue(delegateType, out method))
            {
                return method;
            }
            return null;
        }

        // 注册新类型, 会增加 proto 的引用计数
        public int AddType(Type type, JSValue proto)
        {
            JSValue old_proto;
            if (_prototypes.TryGetValue(type, out old_proto))
            {
                JSApi.JS_FreeValue(_context, old_proto);
                _prototypes[type] = JSApi.JS_DupValue(_context, proto);
                return _typeIndex[type];
            }

            _prototypes[type] = JSApi.JS_DupValue(_context, proto);
            _types.Add(type);
            var index = _types.Count;
            _typeIndex[type] = index;
            return index;
        }

        public Type GetType(int index)
        {
            return index >= 1 && index <= _types.Count ? _types[index - 1] : null;
        }

        public int GetTypeID(Type type)
        {
            int index;
            if (_typeIndex.TryGetValue(type, out index))
            {
                return index;
            }

            return -1;
        }

        // 将 type 的 prototype 压栈 （未导出则向父类追溯）
        // without reference-count added
        public JSValue FindChainedPrototypeOf(Type cType, out int type_id)
        {
            if (cType == null)
            {
                type_id = -1;
                return JSApi.JS_UNDEFINED;
            }

            JSValue proto;
            if (TryGetPrototypeOf(cType, out proto))
            {
                type_id = GetTypeID(cType);
                return proto;
            }

            return FindChainedPrototypeOf(cType.BaseType, out type_id);
        }

        public JSValue FindChainedPrototypeOf(Type cType)
        {
            if (cType == null)
            {
                return JSApi.JS_UNDEFINED;
            }

            if (cType == typeof(Enum))
            {
                return JSApi.JS_UNDEFINED;
            }

            JSValue proto;
            if (TryGetPrototypeOf(cType, out proto))
            {
                return proto;
            }

            return FindChainedPrototypeOf(cType.BaseType);
        }

        public JSValue FindChainedPrototypeOf(Type cType, out Type pType)
        {
            if (cType == null)
            {
                pType = null;
                return JSApi.JS_UNDEFINED;
            }

            if (cType == typeof(Enum))
            {
                pType = null;
                return JSApi.JS_UNDEFINED;
            }

            JSValue proto;
            if (TryGetPrototypeOf(cType, out proto))
            {
                pType = cType;
                return proto;
            }

            return FindChainedPrototypeOf(cType.BaseType, out pType);
        }

        public bool TryGetPrototypeOf(Type type, out JSValue proto)
        {
            if (_prototypes.TryGetValue(type, out proto))
            {
                return true;
            }

            if (_runtime.EnsureReflectBindTypeLoaded(_context, type))
            {
                if (_prototypes.TryGetValue(type, out proto))
                {
                    return true;
                }
            }

            proto = JSApi.JS_UNDEFINED;
            return false;
        }

        public JSValue GetPrototypeOf(Type type)
        {
            JSValue proto;
            if (TryGetPrototypeOf(type, out proto))
            {
                return proto;
            }

            return JSApi.JS_UNDEFINED;
        }

        public JSValue FindPrototypeOf(Type type, out int type_id)
        {
            JSValue proto;
            if (TryGetPrototypeOf(type, out proto))
            {
                type_id = GetTypeID(type);
                return proto;
            }

            type_id = -1;
            return JSApi.JS_UNDEFINED;
        }

        public JSValue GetConstructorOf(Type type)
        {
            var proto = GetPrototypeOf(type);
            return JSApi.JS_GetProperty(_context, proto, JSApi.JS_ATOM_constructor);
        }

        public void Destroy()
        {
            var ctx = (JSContext)_context;
            foreach (var kv in _prototypes)
            {
                var jsValue = kv.Value;
                JSApi.JS_FreeValue(ctx, jsValue);
            }

            _prototypes.Clear();
        }

        public static Type GetType(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            var type = Assembly.GetExecutingAssembly().GetType(name);
            return type;
        }

        public JSValue NewDynamicMethod(JSAtom name, JSCFunction method)
        {
            return NewDynamicMethod(name, new DynamicMethodInvoke(method));
        }

        public JSValue NewDynamicDelegate(JSAtom name, Delegate d)
        {
            if (d == null)
            {
                return JSApi.JS_NULL;
            }

            var method = new DynamicDelegateMethod(d);
            var magic = _dynamicMethods.Count;
            var funValue = JSApi.JSB_NewCFunctionMagic(_context, JSApi._DynamicMethodInvoke, name, 0, JSCFunctionEnum.JS_CFUNC_generic_magic, magic);
            _dynamicMethods.Add(method);
            return funValue;
        }

        public JSValue NewDynamicMethod(JSAtom name, IDynamicMethod method)
        {
            if (method == null)
            {
                var funValue = JSApi.JSB_NewCFunctionMagic(_context, JSApi.class_private_ctor, name, 0, JSCFunctionEnum.JS_CFUNC_generic_magic, 0);
                return funValue;
            }
            else
            {
                var magic = _dynamicMethods.Count;
                var funValue = JSApi.JSB_NewCFunctionMagic(_context, JSApi._DynamicMethodInvoke, name, 0, JSCFunctionEnum.JS_CFUNC_generic_magic, magic);
                _dynamicMethods.Add(method);
                return funValue;
            }
        }

        public JSValue NewDynamicConstructor(JSAtom name, IDynamicMethod method)
        {
            if (method == null)
            {
                var funValue = JSApi.JSB_NewCFunctionMagic(_context, JSApi.class_private_ctor, name, 0, JSCFunctionEnum.JS_CFUNC_constructor_magic, 0);
                return funValue;
            }
            else
            {
                var magic = _dynamicMethods.Count;
                var funValue = JSApi.JSB_NewCFunctionMagic(_context, JSApi._DynamicMethodInvoke, name, 0, JSCFunctionEnum.JS_CFUNC_constructor_magic, magic);
                _dynamicMethods.Add(method);
                return funValue;
            }
        }

        public void NewDynamicFieldAccess(JSAtom name, IDynamicField field, out JSValue getter, out JSValue setter)
        {
            var magic = _dynamicFields.Count;
            getter = JSApi.JSB_NewCFunction(_context, JSApi._DynamicFieldGetter, name, magic);
            setter = JSApi.JSB_NewCFunction(_context, JSApi._DynamicFieldSetter, name, magic);
            _dynamicFields.Add(field);
        }

        public IDynamicMethod GetDynamicMethod(int index)
        {
            return index >= 0 && index < _dynamicMethods.Count ? _dynamicMethods[index] : null;
        }

        public IDynamicField GetDynamicField(int index)
        {
            return index >= 0 && index < _dynamicFields.Count ? _dynamicFields[index] : null;
        }
    }
}