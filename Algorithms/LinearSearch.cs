using SearchingSorting.Models;
using SearchingSorting.Enums;
using SearchingSorting.Services;

namespace SearchingSorting.Algorithms;

public class LinearSearch
{
    public static Contact? Search(Contact[] contacts, string searchTerm, Field field, out int comparisons)
    {
        comparisons = 0;
        foreach (Contact contact in contacts)
        {
            comparisons++;
            string value = ContactComparer.GetFieldValue(contact, field);
            if (ContactComparer.Compare(value, searchTerm) == 0)
            {
                return contact;
            }
        }
        return null;
    }
}