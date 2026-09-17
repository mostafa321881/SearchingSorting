using SearchingSorting.Models;
using SearchingSorting.Enums;
using SearchingSorting.Services;

namespace SearchingSorting.Algorithms;

public class LinearSearch
{
    /// <summary>
    /// Searches all contacts for exact, case-insensitive matches in the selected field.
    /// Returns every matching contact.
    /// Time complexity: O(n).
    /// Space complexity: O(n) in the worst case for the returned matches.
    /// </summary>
    public static Contact[] Search(
        Contact[] contacts,
        string searchTerm,
        Field field,
        out int comparisons)
    {
        if (contacts == null)
        {
            throw new ArgumentNullException(nameof(contacts));
        }

        if (searchTerm == null)
        {
            throw new ArgumentNullException(nameof(searchTerm));
        }

        comparisons = 0;
        List<Contact> matches = new List<Contact>();

        foreach (Contact contact in contacts)
        {
            comparisons++;

            string value =
                ContactComparer.GetFieldValue(contact, field);

            if (ContactComparer.Compare(value, searchTerm) == 0)
            {
                matches.Add(contact);
            }
        }

        return matches.ToArray();
    }
}