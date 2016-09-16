## Linq

### Generator

    Enumerable
        .Range(1, 49)
        .OrderBy(x => Guid.NewGuid())
        .Take(6);