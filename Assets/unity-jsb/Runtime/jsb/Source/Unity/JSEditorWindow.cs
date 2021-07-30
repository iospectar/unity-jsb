#if !JSB_UNITYLESS
#if UNITY_EDITOR
using System;
using System.Reflection;

namespace QuickJS.Unity
{
    using Native;
    using UnityEngine;
    using UnityEditor;

    /// <summary>
    /// 脚本实现编辑器窗口的基础类. 
    /// 此实现刻意放在非 Editor 目录下, 以便在非编辑器脚本中也可以使用, 实际仍然只在编辑器环境下可用.
    /// </summary>
    public class JSEditorWindow : EditorWindow, IHasCustomMenu
    {
        private bool _released;
        private bool _destroyed;

        private string _moduleId;
        private string _className;

        private JSContext _ctx;
        private JSValue _this_obj;

        private bool _updateValid;
        private JSValue _updateFunc;

        private bool _onEnableValid;
        private JSValue _onEnableFunc;

        private bool _onDisableValid;
        private JSValue _onDisableFunc;

        private bool _onDestroyValid;
        private JSValue _onDestroyFunc;

        private bool _onGUIValid;
        private JSValue _onGUIFunc;

        private bool _addItemsToMenuValid;
        private JSValue _addItemsToMenuFunc;

        public int IsInstanceOf(JSValue ctor)
        {
            if (_released)
            {
                return 0;
            }
            return JSApi.JS_IsInstanceOf(_ctx, _this_obj, ctor);
        }

        public JSValue CloneValue()
        {
            if (_released)
            {
                return JSApi.JS_UNDEFINED;
            }
            return JSApi.JS_DupValue(_ctx, _this_obj);
        }

        public void SetBridge(JSContext ctx, JSValue this_obj, JSValue ctor)
        {
            var context = ScriptEngine.GetContext(ctx);
            if (context == null)
            {
                return;
            }

            _moduleId = null;
            _className = null;
            context.ForEachModuleExport((mod_id_atom, exp_id_atom, exp_obj) =>
            {
                if (exp_obj == ctor)
                {
                    _moduleId = JSApi.GetString(ctx, mod_id_atom);
                    _className = JSApi.GetString(ctx, exp_id_atom);
                    return true;
                }

                return false;
            });

            context.OnDestroy += OnContextDestroy;
#if UNITY_EDITOR
            if (!string.IsNullOrEmpty(_moduleId) && !string.IsNullOrEmpty(_className))
            {
                context.OnScriptReloading += OnScriptReloading;
                context.OnScriptReloaded += OnScriptReloaded;
            }
#endif
            _released = false;
            _ctx = ctx;
            _this_obj = JSApi.JS_DupValue(ctx, this_obj);

            BindJSMembers(context);

            var awake_obj = JSApi.JS_GetProperty(ctx, this_obj, context.GetAtom("Awake"));

            Call(awake_obj);
            JSApi.JS_FreeValue(_ctx, awake_obj);
            if (_onEnableValid)
            {
                Call(_onEnableFunc);
            }
        }

        private void BindJSMembers(ScriptContext context)
        {
            var ctx = (JSContext)context;

            _updateFunc = JSApi.JS_GetProperty(ctx, _this_obj, context.GetAtom("Update"));
            _updateValid = JSApi.JS_IsFunction(ctx, _updateFunc) == 1;

            _onEnableFunc = JSApi.JS_GetProperty(ctx, _this_obj, context.GetAtom("OnEnable"));
            _onEnableValid = JSApi.JS_IsFunction(ctx, _onEnableFunc) == 1;

            _onDisableFunc = JSApi.JS_GetProperty(ctx, _this_obj, context.GetAtom("OnDisable"));
            _onDisableValid = JSApi.JS_IsFunction(ctx, _onDisableFunc) == 1;

            _onDestroyFunc = JSApi.JS_GetProperty(ctx, _this_obj, context.GetAtom("OnDestroy"));
            _onDestroyValid = JSApi.JS_IsFunction(ctx, _onDestroyFunc) == 1;

            _onGUIFunc = JSApi.JS_GetProperty(ctx, _this_obj, context.GetAtom("OnGUI"));
            _onGUIValid = JSApi.JS_IsFunction(ctx, _onGUIFunc) == 1;

            _addItemsToMenuFunc = JSApi.JS_GetProperty(ctx, _this_obj, context.GetAtom("AddItemsToMenu"));
            _addItemsToMenuValid = JSApi.JS_IsFunction(ctx, _addItemsToMenuFunc) == 1;
        }

        private void UnbindJSMembers()
        {
            JSApi.JS_FreeValue(_ctx, _updateFunc);
            _updateFunc = JSApi.JS_UNDEFINED;
            _updateValid = false;

            JSApi.JS_FreeValue(_ctx, _onEnableFunc);
            _onEnableFunc = JSApi.JS_UNDEFINED;
            _onEnableValid = false;

            JSApi.JS_FreeValue(_ctx, _onDisableFunc);
            _onDisableFunc = JSApi.JS_UNDEFINED;
            _onDisableValid = false;

            JSApi.JS_FreeValue(_ctx, _onDestroyFunc);
            _onDestroyFunc = JSApi.JS_UNDEFINED;
            _onDestroyValid = false;

            JSApi.JS_FreeValue(_ctx, _onGUIFunc);
            _onGUIFunc = JSApi.JS_UNDEFINED;
            _onGUIValid = false;

            JSApi.JS_FreeValue(_ctx, _addItemsToMenuFunc);
            _addItemsToMenuFunc = JSApi.JS_UNDEFINED;
            _addItemsToMenuValid = false;
        }

        private void Call(JSValue func_obj)
        {
            if (JSApi.JS_IsFunction(_ctx, func_obj) == 1)
            {
                var rval = JSApi.JS_Call(_ctx, func_obj, _this_obj);
                if (rval.IsException())
                {
                    _ctx.print_exception();
                }
                JSApi.JS_FreeValue(_ctx, rval);
            }
        }

#if UNITY_EDITOR
        private void OnScriptReloading(ScriptContext context, string resolved_id)
        {
            if (_moduleId == resolved_id)
            {

            }
        }

        private void OnScriptReloaded(ScriptContext context, string resolved_id)
        {
            if (_moduleId == resolved_id)
            {
                //NOTE: now the EditorWindow use different mechanism to reload script, 
                // Editor/MonoBehaviour/ScriptObject will be updated to the same later soon.

                JSValue newClass;
                if (context.LoadModuleCacheExports(resolved_id, _className, out newClass))
                {
                    var prototype = JSApi.JS_GetProperty(context, newClass, context.GetAtom("prototype"));

                    if (prototype.IsObject())
                    {
                        UnbindJSMembers();
                        JSApi.JS_SetPrototype(context, _this_obj, prototype);
                        BindJSMembers(context);
                    }

                    JSApi.JS_FreeValue(context, prototype);
                    JSApi.JS_FreeValue(context, newClass);
                }
            }
        }
#endif

        private void OnContextDestroy(ScriptContext context)
        {
            Release();
        }

        void Release()
        {
            if (_released)
            {
                return;
            }

            _released = true;

            UnbindJSMembers();
            JSApi.JS_FreeValue(_ctx, _this_obj);

            var context = ScriptEngine.GetContext(_ctx);
            if (context != null)
            {
                context.OnDestroy -= OnContextDestroy;
#if UNITY_EDITOR
                context.OnScriptReloading -= OnScriptReloading;
                context.OnScriptReloaded -= OnScriptReloaded;
#endif
            }

            if (!_destroyed)
            {
                try
                {
                    Close();
                }
                catch (Exception) { }
            }
        }

        void Update()
        {
            if (_updateValid)
            {
                var rval = JSApi.JS_Call(_ctx, _updateFunc, _this_obj);
                if (rval.IsException())
                {
                    _ctx.print_exception();
                }
                JSApi.JS_FreeValue(_ctx, rval);
            }
        }

        void OnEnable()
        {
            if (_onEnableValid)
            {
                var rval = JSApi.JS_Call(_ctx, _onEnableFunc, _this_obj);
                if (rval.IsException())
                {
                    _ctx.print_exception();
                }
                JSApi.JS_FreeValue(_ctx, rval);
            }
        }

        void OnDisable()
        {
            if (_onDisableValid)
            {
                var rval = JSApi.JS_Call(_ctx, _onDisableFunc, _this_obj);
                if (rval.IsException())
                {
                    _ctx.print_exception();
                }
                JSApi.JS_FreeValue(_ctx, rval);
            }
            if (UnityEditor.EditorApplication.isCompiling)
            {
                Release();
            }
        }

        void OnDestroy()
        {
            if (_destroyed)
            {
                return;
            }

            if (_onDestroyValid)
            {
                var rval = JSApi.JS_Call(_ctx, _onDestroyFunc, _this_obj);
                if (rval.IsException())
                {
                    _ctx.print_exception();
                }
                JSApi.JS_FreeValue(_ctx, rval);
            }
            _destroyed = true;
            Release();
        }

        void OnGUI()
        {
            if (_onGUIValid)
            {
                var rval = JSApi.JS_Call(_ctx, _onGUIFunc, _this_obj);
                if (rval.IsException())
                {
                    _ctx.print_exception();
                }
                JSApi.JS_FreeValue(_ctx, rval);
            }
        }

        public unsafe void AddItemsToMenu(GenericMenu menu)
        {
            if (_addItemsToMenuValid)
            {
                var argv = stackalloc JSValue[] { Binding.Values.js_push_classvalue(_ctx, menu) };
                var rval = JSApi.JS_Call(_ctx, _addItemsToMenuFunc, _this_obj, 1, argv);

                JSApi.JS_FreeValue(_ctx, argv[0]);
                if (rval.IsException())
                {
                    _ctx.print_exception();
                }
                JSApi.JS_FreeValue(_ctx, rval);
            }
        }
    }
}
#endif
#endif
