## Null Object design pattern

    interface ILogger
    {
        void Information(string text);
    }

    class NullLogger : ILogger
    {
        void Information(string text) { }
    }

    static void Main()
    {
        new Service(new NullLog()).DoIt();
    }

