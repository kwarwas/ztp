## Maybe

    var text = Maybe<string>.Nothing;

    text.Match
    (
        Console.WriteLine,
        () => Console.WriteLine("Błąd")
    );

    var str = text.OrElse("--brak--");

https://github.com/AndreyTsvetkov/Functional.Maybe
