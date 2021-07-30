﻿using QuickJS.Native;
using System.Runtime.InteropServices;

namespace QuickJS.Utils
{
    public delegate void JSActionCallback(ScriptRuntime runtime, JSAction action);

    // [StructLayout(LayoutKind.Sequential)]
    public struct JSAction
    {
        public JSValue value;
        public JSActionCallback callback;
        public object args; 
    }
}