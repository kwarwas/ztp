## Good or bad code?

    IEnumerable<Person> Method(ICollection<Person> collection)
    {
        return collection.Where(x => x.FirstName.EndsWith("a"));
    }