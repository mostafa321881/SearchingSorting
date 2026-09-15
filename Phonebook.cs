using SearchingSorting.Models;

namespace SearchingSorting;

public class Phonebook
{
    private readonly Contact[] _contacts;

    public Phonebook(Contact[] contacts)
    {
        _contacts = contacts;
    }
    public Contact? FindByFirstName(string firstName)
    {
        foreach (Contact contact in _contacts)
        {
            if (contact.FirstName == firstName)
            {
                return contact;
            }
        }

        return null;
    }
}