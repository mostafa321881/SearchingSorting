using SearchingSorting.Models;
using SearchingSorting.Enums;
using SearchingSorting.Services;

namespace SearchingSorting.Algorithms;

public class BinarySearch
{
    /// <summary>
    /// Searches an array that is already sorted in ascending order
    /// by the selected field.
    /// Returns the lowest index when duplicate values exist.
    /// Returns -1 when the target is not found.
    /// Time complexity: O(log n).
    /// Space complexity: O(1).
    /// </summary>
    public static int Search(
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

        int left = 0;
        int right = contacts.Length - 1;
        int firstMatchIndex = -1;

        while (left <= right)
        {
            int middle = left + (right - left) / 2;

            string middleValue =
                ContactComparer.GetFieldValue(contacts[middle], field);

            comparisons++;

            int result =
                ContactComparer.Compare(middleValue, searchTerm);

            if (result == 0)
            {
                firstMatchIndex = middle;

                // Continue searching to the left because
                // there may be an earlier duplicate.
                right = middle - 1;
            }
            else if (result < 0)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return firstMatchIndex;
    }
}