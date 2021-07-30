﻿using System.Collections.Generic;

namespace QuickJS.Utils
{
    using Native;

    public class SafeRelease
    {
        private ScriptContext _context;
        private List<JSValue> _values = new List<JSValue>();

        public JSValue this[int index]
        {
            get { return _values[index]; }
        }

        public bool isValid => _context != null;

        public SafeRelease(ScriptContext context)
        {
            _context = context;
            _context.OnDestroy += OnDestroy;
        }

        public SafeRelease(ScriptContext context, JSValue value)
        {
            _context = context;
            _values.Add(value);
            _context.OnDestroy += OnDestroy;
        }

        public SafeRelease(ScriptContext context, JSValue value1, JSValue value2)
        {
            _context = context;
            _values.Add(value1);
            _values.Add(value2);
            _context.OnDestroy += OnDestroy;
        }

        public JSValue[] ToArray()
        {
            return _values.ToArray();
        }

        public SafeRelease Append(params JSValue[] values)
        {
            for (int i = 0, size = values.Length; i < size; i++)
            {
                _values.Add(values[i]);
            }

            return this;
        }

        private void OnDestroy(ScriptContext context)
        {
            Release();
        }

        public void Release()
        {
            if (_context != null)
            {
                var context = _context;
                _context = null;
                context.OnDestroy -= OnDestroy;
                var len = _values.Count;
                for (var i = 0; i < len; i++)
                {
                    JSApi.JS_FreeValue(context, _values[i]);
                }

                _values.Clear();
            }
        }
    }
}