## Good or bad code?

    string result = null;
    if (person != null)
    {
        if (person.Work != null)
        {
            if (person.Work.Phone != null)
            {
                result = person.Work.Phone.Code;
            }
        }
    }
    if (result != null)
    {
        Console.WriteLine(result);
    }