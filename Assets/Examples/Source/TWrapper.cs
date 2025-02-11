
public class TWrapper<T>
{
    private T _obj;

    public TWrapper(T obj)
    {
        _obj = obj;
    }

    public T GetValue()
    {
        return _obj;
    }

    public void SetValue(T obj)
    {
        _obj = obj;
    }

    public static TWrapper<int> GetIntWrapper()
    {
        return null;
    }
}

namespace AnotherNamespace1
{
    public class Dummy
    {
        public class DummyInner
        {

        }
    }

    public class TSCodeGenTest
    {
        public class InnerClass<T>
        {
            public static TWrapper<T> GetIntWrapper()
            {
                return null;
            }
        }
    }

    public class TSCodeGenTest2<T>
    {
        public T GetValue()
        {
            return default(T);
        }
    }
}

namespace AnotherNamespace2
{
    public class TSCodeGenTest
    {
        //TODO ts codegen support
        public static AnotherNamespace1.TSCodeGenTest.InnerClass<int> GetInnerClass()
        {
            return null;
        }

        public static AnotherNamespace1.TSCodeGenTest2<int> GetTSCodeGenTest2()
        {
            return null;
        }

        public static AnotherNamespace1.TSCodeGenTest2<AnotherNamespace1.Dummy> GetTSCodeGenTest2Dummy()
        {
            return null;
        }

        public static AnotherNamespace1.TSCodeGenTest2<AnotherNamespace1.Dummy.DummyInner> GetTSCodeGenTest2DummyInner()
        {
            return null;
        }
    }
}