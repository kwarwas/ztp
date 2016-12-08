## Method Signature Honesty

    public Maybe<int> Divide(int a, int b)
    {
        return (b != 0).Then(() => a / b);
    }

`Install-Package Functional.Maybe`