#if !JSB_UNITYLESS
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace QuickJS.Unity
{
    using UnityEngine;
    using UnityEditor;
    using QuickJS.Binding;

    public class ScriptEditorWindowLauncher : BaseEditorWindow
    {
        private List<JSScriptClassPathHint> _classPaths;

        void Awake()
        {
            Reset();
        }

        void OnDestroy()
        {
            JSScriptFinder.GetInstance().ScriptClassPathsUpdated -= OnScriptClassPathsUpdated;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            var scriptIcon = EditorGUIUtility.IconContent("d_Js Script Icon");
            titleContent = new GUIContent("EditorWindow Launcher", scriptIcon?.image);
        }

        private void OnScriptClassPathsUpdated()
        {
            _classPaths.Clear();
            JSScriptFinder.GetInstance().Search(JSScriptClassType.EditorWindow, _classPaths);
        }

        private void DrawScriptItem(JSScriptClassPathHint classPath)
        {
            var scriptIcon = EditorGUIUtility.IconContent("d_Js Script Icon");
            if (GUILayout.Button(scriptIcon, GUILayout.Width(64f), GUILayout.Height(64f)))
            {
                EditorRuntime.ShowWindow(classPath.modulePath, classPath.className);
            }
            EditorGUILayout.LabelField(classPath.className);
        }

        private void Reset()
        {
            JSScriptFinder.GetInstance().ScriptClassPathsUpdated -= OnScriptClassPathsUpdated;
            JSScriptFinder.GetInstance().ScriptClassPathsUpdated += OnScriptClassPathsUpdated;
            _classPaths = new List<JSScriptClassPathHint>();
            JSScriptFinder.GetInstance().Search(JSScriptClassType.EditorWindow, _classPaths);
        }

        protected override void OnPaint()
        {
            if (_classPaths == null) {
                Reset();
            }
            
            var size = _classPaths.Count;
            EditorGUILayout.HelpBox("ScriptEditorWindowLauncher is an experimental unfinished feature. it could be used to open editor windows implemented in typescript, we need this because there is no open api in Unity to dynamically create menu item at the moment.", MessageType.Warning);
            EditorGUILayout.HelpBox(string.Format("{0} EditorWindow Scripts", size), MessageType.Info);
            for (var i = 0; i < size; i++)
            {
                var item = _classPaths[i];

                DrawScriptItem(item);
            }
        }
    }
}
#endif
