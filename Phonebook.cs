using SearchingSorting.Models;

namespace SearchingSorting;

public class Phonebook
{
    private readonly Contact[] _contacts;

    /// <summary>
    /// Creates a phonebook containing the supplied contacts.
    /// </summary>
    public Phonebook(Contact[] contacts)
    {
        if (contacts == null)
        {
            throw new ArgumentNullException(nameof(contacts));
        }

        _contacts = (Contact[])contacts.Clone();
    }

    /// <summary>
    /// Returns a copy of the contacts stored in the phonebook.
    /// </summary>
    public Contact[] GetContacts()
    {
        return (Contact[])_contacts.Clone();
    }
}