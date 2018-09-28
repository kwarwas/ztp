using System;
using System.Dynamic;
using ImpromptuInterface;
using Serilog;

namespace NullObject
{
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

    class NullLog<TInterface> : DynamicObject where TInterface : class
    {
        public static TInterface Instance => new NullLog<TInterface>().ActLike<TInterface>();

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = Activator.CreateInstance(binder.ReturnType);
            return true;
        }
    }
    
    class Program
    {
        static void Main()
        {
            var log = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            new Service(NullLog<ILogger>.Instance).DoIt();
        }
    }
}