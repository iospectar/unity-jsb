﻿using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace QuickJS.Binding
{
    using Native;

    public partial class Values
    {
        public const string KeyForCSharpTypeID = "__csharp_type_id__";

        static Values()
        {
            init_cast_map();
        }

        public static bool IsVarargParameter(ParameterInfo[] parameters)
        {
            return parameters.Length > 0 && parameters[parameters.Length - 1].IsDefined(typeof(ParamArrayAttribute), false);
        }

        /// <summary>
        /// 全局查找目标类型
        /// </summary>
        public static Type FindType(string type_name)
        {
            Type type = null; //Assembly.GetExecutingAssembly().GetType(type_name);
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            for (int i = 0, count = assemblies.Length; i < count; i++)
            {
                var assembly = assemblies[i];
                type = assembly.GetType(type_name);
                if (type != null)
                {
                    break;
                }
            }
            return type;
        }

        public static bool IsContextualType(Type pType)
        {
            return pType == typeof(JSContext) || pType == typeof(JSRuntime)
                || pType == typeof(ScriptContext) || pType == typeof(ScriptRuntime);
        }

        public static object js_get_context(JSContext ctx, Type type)
        {
            if (type == typeof(JSContext))
            {
                return ctx;
            }

            if (type == typeof(JSRuntime))
            {
                return JSApi.JS_GetRuntime(ctx);
            }

            if (type == typeof(ScriptContext))
            {
                return ScriptEngine.GetContext(ctx);
            }

            if (type == typeof(ScriptRuntime))
            {
                return ScriptEngine.GetRuntime(ctx);
            }

            return null;
        }

        public static JSValue FindPrototypeOf<T>(JSContext ctx)
        {
            int type_id;
            var types = ScriptEngine.GetTypeDB(ctx);
            return types.FindChainedPrototypeOf(typeof(T), out type_id);
        }

        public static JSValue FindPrototypeOf(JSContext ctx, Type type)
        {
            int type_id;
            var types = ScriptEngine.GetTypeDB(ctx);
            return types.FindChainedPrototypeOf(type, out type_id);
        }

        protected static bool js_script_error(JSContext ctx)
        {
            var logger = ScriptEngine.GetLogger(ctx);
            if (logger != null)
            {
                logger.Write(Utils.LogLevel.Error, ctx.GetExceptionString());
            }
            return false;
        }
    }
}
