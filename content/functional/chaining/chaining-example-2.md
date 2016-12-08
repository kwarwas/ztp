## Method chaining - example

    Process.GetProcesses()
        .Where(x => x.Threads.Count > 5)
        .OrderBy(x => x.ProcessName)
        .Select(x => x.ProcessName)
        .Distinct();

> C# – LINQ, http://prasadhonrao.com/method-chaining-design-pattern-in-c-and-javascript/