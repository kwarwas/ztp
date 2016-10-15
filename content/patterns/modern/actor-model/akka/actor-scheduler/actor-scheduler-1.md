## Akka.NET - Actor Scheduler

    var system = ActorSystem.Create("MySystem");
    var someActor = system.ActorOf<SomeActor>("someActor");
    var someMessage = new SomeMessage() {...};
    system
       .Scheduler
       .Schedule(TimeSpan.FromSeconds(0),
                 TimeSpan.FromSeconds(5),
                 someActor, someMessage);
