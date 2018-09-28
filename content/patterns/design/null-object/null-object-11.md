## Null Object design pattern

** impromptu-interface **

Static interface to dynamic implementation (duck casting)

    class NullLogger<TInterface> : DynamicObject where TInterface : class
    {
        public static TInterface Instance => new NullLog<TInterface>().ActLike<TInterface>();

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = Activator.CreateInstance(binder.ReturnType);
            return true;
        }
    }

https://www.nuget.org/packages/ImpromptuInterface
https://github.com/ekonbenefits/impromptu-interface
