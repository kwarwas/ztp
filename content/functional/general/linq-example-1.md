## LINQ example

- $f_1: X \to X$
    - First-order functions
        - `IEnumerable<T> Take<T>(this IEnumerable<T> source, int count)`
        - `IEnumerable<T> Skip<T>(this IEnumerable<T> source, int count)`
    - Higher-order function
        - `IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)`
        - `IEnumerable<T> TakeWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)`
        - `IEnumerable<T> SkipWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)`
