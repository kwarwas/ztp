## Good or bad code?

    IEnumerable<Person> Method(ICollection<Person> collection)
    {
        foreach (var item in collection)
        {
            if (item.FirstName.EndsWith("a"))
            {
                yield return item;
            }
        }
    }