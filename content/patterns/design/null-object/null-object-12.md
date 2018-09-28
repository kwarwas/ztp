## Null Object design pattern

    static void Main()
    {
        new Service(NullLogger<ILogger>.Instance).DoIt();
    }

https://www.nuget.org/packages/ImpromptuInterface
https://github.com/ekonbenefits/impromptu-interface