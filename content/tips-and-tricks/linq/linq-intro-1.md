## Good or bad code?

    IEnumerable<Person> Method(ICollection<Person> collection)
    {
        var result = new List<Person>();

        foreach (var item in collection)
        {
            if (item.FirstName.EndsWith("a"))
            {
                result.Add(item);
            }
        }

        return result;
    }