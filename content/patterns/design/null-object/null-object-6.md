## Null Object design pattern

    class Program
    {
        static void Main()
        {
            var log = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            
            new Service(log).DoIt();
        }
    }

(Serilog with Console.Sink)