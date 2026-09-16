using SearchingSorting.Models;
using SearchingSorting.Enums;
using SearchingSorting.Services;

namespace SearchingSorting.Algorithms;

public class BinarySearch
{
    public static Contact? Search(
        Contact[] contacts,
        string searchTerm,
        Field field,
        SortOrder order,
        out int comparisons)
    {
        comparisons = 0;

        int left = 0;
        int right = contacts.Length - 1;

        while (left <= right)
        {
            int middle = (left + right) / 2;

            string middleValue =
                ContactComparer.GetFieldValue(contacts[middle], field);

            comparisons++;

            int result =
                ContactComparer.Compare(middleValue, searchTerm);

            if (result == 0)
            {
                return contacts[middle];
            }

            if (order == SortOrder.Ascending)
            {
                if (result < 0)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
            else
            {
                if (result > 0)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
        }

        return null;
    }
}