using SearchingSorting.Enums;
using SearchingSorting.Models;

namespace SearchingSorting.Services;

public class ContactComparer
{
    /// <summary>
    /// Gets the value of the selected searchable field from a contact.
    /// </summary>
    public static string GetFieldValue(Contact contact, Field field)
    {
        if (contact == null)
        {
            throw new ArgumentNullException(nameof(contact));
        }

        return field switch
        {
            Field.FirstName => contact.FirstName,
            Field.LastName => contact.LastName,
            Field.Mobile => contact.Mobile,
            _ => throw new ArgumentOutOfRangeException(nameof(field))
        };
    }

    /// <summary>
    /// Compares two string values using a case-insensitive ordinal comparison.
    /// </summary>
    public static int Compare(string firstValue, string secondValue)
    {
        if (firstValue == null)
        {
            throw new ArgumentNullException(nameof(firstValue));
        }

        if (secondValue == null)
        {
            throw new ArgumentNullException(nameof(secondValue));
        }

        return string.Compare(
            firstValue,
            secondValue,
            StringComparison.OrdinalIgnoreCase);
    }
}