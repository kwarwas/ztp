## LINQ example

- $f_2: X \to Y$
    - First-order functions
        - `bool Any<T>(this IEnumerable<T> source)`
        - `T Single<T>(this IEnumerable<T> source)`
        - `int Min(this IEnumerable<int> source)`
    - Higher-order function
        - `bool Any<T>(this IEnumerable<T> source, Func<T, bool> predicate)`
        - `IEnumerable<U> Select<T, U>(this IEnumerable<T> source, Func<T, U> selector)`
        - `int Min<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)`
