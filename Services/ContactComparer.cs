using SearchingSorting.Enums;
using SearchingSorting.Models;

namespace SearchingSorting.Services;

public class ContactComparer
{
    public static string GetFieldValue(Contact contact, Field field)
    {
        return field switch
        {
            Field.FirstName => contact.FirstName,
            Field.LastName => contact.LastName,
            Field.Mobile => contact.Mobile,
            _ => throw new ArgumentOutOfRangeException(nameof(field))
        };
    }

    public static int Compare(string firstValue, string secondValue)
        {
            return string.Compare(firstValue, secondValue, StringComparison.OrdinalIgnoreCase);
        }
    
}