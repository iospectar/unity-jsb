using System;
using System.Collections.Generic;

namespace QuickJS.Binding
{
    // js-bridge 配置 (editor only)
    public class Prefs
    {
        #region Configurable Fields

        /// <summary>
        /// 代码生成过程的日志输出到文件中
        /// </summary>
        public string logPath = "Logs/js-bridge.log";

        /// <summary>
        /// JSBehaviourScriptRef.sourceFile 将基于 sourceDir 拆出对应的 modulePath
        /// </summary>
        public string sourceDir = "Scripts/src";

        /// <summary>
        /// 静态绑定代码的生成目录
        /// </summary>
        public string outDir = "Assets/Generated/${platform}";

        /// <summary>
        /// 绑定代码对应 ts 声明文件生成目录
        /// </summary>
        public string typescriptDir = "Assets/Generated/Typings";

        /// <summary>
        /// 编辑器搜索脚本源码时匹配的后缀名
        /// </summary>
        public string typescriptExt = ".ts";

        /// <summary>
        /// Assembly-CSharp.dll 对应的 XmlDoc 生成目录
        /// </summary>
        public string xmlDocDir = "Assets/Generated/Docs";

        /// <summary>
        /// 生成绑定代码时输出一份 JS 模块列表信息
        /// </summary>
        public string jsModulePackInfoPath = "jsb-modules.json";

        /// <summary>
        /// 是否生成 typescript 声明文件中的文档注释
        /// </summary>
        public bool genTypescriptDoc = true;

        /// <summary>
        /// 默认启用编辑器脚本执行相关功能 (JSEditorWindow 等)
        /// </summary>
        public bool editorScripting = true;

        /// <summary>
        /// [编辑器环境] 在没有生成绑定代码的情况下, 是否支持反射绑定 (以便在开发期无需生成绑定代码)
        /// (此功能未完成)
        /// </summary>
        public bool reflectBinding = true;

        /// <summary>
        /// 启用运算符重载转换 (禁用后运算符将以 op_* 的形式导出为函数)
        /// </summary>
        public bool enableOperatorOverloading = true;

        /// <summary>
        /// 编辑器运行时脚本入口
        /// </summary>
        public string editorEntryPoint = "editor/main";

        public List<string> editorRequires = new List<string>(new string[]
        {
            "plover/editor/js_reload"
        });

        /// <summary>
        /// 代码生成调试开关, 生成的代码将完全在注释中, 方便反复生成对比查问题
        /// </summary>
        public bool debugCodegen = false;

        /// <summary>
        /// 忽略带 ref/out 参数的 delegate 绑定
        /// </summary>
        public bool skipDelegateWithByRefParams = false;

        /// <summary>
        /// 代码生成过程中记录更详细的日志
        /// </summary>
        public bool verboseLog = true;

        /// <summary>
        /// 是否将 C# ToString() 自动转换为 toString()
        /// </summary>
        public bool optToString = true;

        /// <summary>
        /// 是否输出到单个 d.ts 声明文件中
        /// </summary>
        public bool singleTSD = true;

        /// <summary>
        /// 即使只有唯一匹配的方法/函数, 也进行类型检查 
        /// </summary>
        public bool alwaysCheckArgType = false;

        /// <summary>
        /// 即使只有唯一匹配的方法/函数, 也进行参数数量检查 
        /// </summary>
        public bool alwaysCheckArgc = true;

        /// <summary>
        /// [EXPERIMENTAL, UNFINISHED] 生成的代码随机化
        /// </summary>
        public bool randomizedBindingCode = false;

        // 生成类型绑定代码类型前缀
        public string typeBindingPrefix = "QuickJS_";

        /// <summary>
        /// 生成的绑定类所在命名空间 (in C#)
        /// </summary>
        public string ns = "jsb";

        /// <summary>
        /// 为没有命名空间的 C# 类型, 指定一个默认模块名
        /// </summary>
        public string defaultJSModule = "global";

        /// <summary>
        /// 生成文件的额外后缀
        /// </summary>
        public string extraExt = "";

        /// <summary>
        /// 生成代码中的换行符风格 (cr, lf, crlf), 不指定时将使用当前平台默认风格
        /// </summary>
        public string newLineStyle = "";

        /// <summary>
        /// 生成代码中的缩进
        /// </summary>
        public string tab = "    ";

        /// <summary>
        /// 跳过指定的 BindingProcess
        /// </summary>
        public List<string> skipExtras = new List<string>(new string[]
        {
            // "FairyGUI",
            // "UnityEditor",
            // "Example",
        });

        /// <summary>
        /// 执行代码生成后对指定的目录进行文件清理 (未在本次生成文件列表中的文件将被删除)
        /// </summary>
        public List<string> cleanupDir = new List<string>(new string[]
        {
            "Assets/Generated",
        });

        // 默认不导出任何类型, 需要指定导出类型列表
        public List<string> explicitAssemblies = new List<string>(new string[]
        {
            // "Assembly-CSharp-firstpass",
            "Assembly-CSharp",
        });

        /// <summary>
        /// 在此列表中指定的指定 Assembly 将默认导出其所包含的所有类型
        /// </summary>
        public List<string> implicitAssemblies = new List<string>(new string[]
        {
            // "UnityEngine",
            // "UnityEngine.CoreModule",
            // "UnityEngine.UIModule",
            // "UnityEngine.TextRenderingModule",
            // "UnityEngine.TextRenderingModule",
            // "UnityEngine.UnityWebRequestWWWModule",
            // "UnityEngine.Physics2DModule",
            // "UnityEngine.AnimationModule",
            // "UnityEngine.TextRenderingModule",
            // "UnityEngine.IMGUIModule",
            // "UnityEngine.UnityWebRequestModule",
            // "UnityEngine.PhysicsModule",
            // "UnityEngine.UI",
        });

        /// <summary>
        /// type.FullName 前缀满足以下任意一条时不会被导出
        /// </summary>
        public List<string> typePrefixBlacklist = new List<string>(new string[]
        {
            "JetBrains.",
            "Unity.Collections.",
            "Unity.Jobs.",
            "Unity.Profiling.",
            "UnityEditor.",
            "UnityEditorInternal.",
            "UnityEngineInternal.",
            "UnityEditor.Experimental.",
            "UnityEngine.Experimental.",
            "Unity.IO.LowLevel.",
            "Unity.Burst.",
            "UnityEngine.Assertions.",
        });
        #endregion

        #region Runtime Methods

        public const string PATH = "js-bridge.json";

        public string newline
        {
            get
            {
                if (newLineStyle == null)
                {
                    return Environment.NewLine;
                }

                switch (newLineStyle.ToLower())
                {
                    case "cr": return "\r";
                    case "lf": return "\n";
                    case "crlf": return "\r\n";
                    default: return Environment.NewLine;
                }
            }
        }

        #endregion
    }
}