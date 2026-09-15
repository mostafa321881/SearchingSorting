using SearchingSorting.Models;

namespace SearchingSorting;

public class Phonebook
{
    private readonly Contact[] _contacts;

    public Phonebook(Contact[] contacts)
    {
        _contacts = contacts;
    }
}