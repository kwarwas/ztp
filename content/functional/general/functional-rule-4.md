## Method Signature Honesty

    public int? Divide(int a, int b)
    {
        if (b == 0)
            return null;

        return a / b;
    }
