## Same input => same result

Good? - Yes

    public int Add(int a, int b)
    {
        return a + b;
    }

Good? - No

    public int DaysLeftInYear()
    {
        return 
            new DateTime(DateTime.Now.Year, 12, 31).DayOfYear - 
            DateTime.Today.DayOfYear;
    }
