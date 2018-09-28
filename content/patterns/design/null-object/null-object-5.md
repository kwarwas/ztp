## Null Object design pattern

    class Service
    {
        private readonly ILogger _logger;

        public Service(ILogger logger)
        {
            _logger = logger;
        }

        public void DoIt()
        {
            _logger.Information("Begin");
            // ...
            _logger.Information("End");
        }
    }

(Serilog with Console.Sink)