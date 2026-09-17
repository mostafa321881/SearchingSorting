using SearchingSorting.Models;
using SearchingSorting.Enums;
using SearchingSorting.Services;

namespace SearchingSorting.Algorithms;

public class MergeSort
{
    /// <summary>
    /// Sorts the contacts in place using Merge Sort.
    /// Supports FirstName, LastName, and Mobile fields,
    /// in ascending or descending order.
    /// Time complexity: O(n log n).
    /// Space complexity: O(n).
    /// </summary>
    public static void Sort(
        Contact[] contacts,
        Field field,
        SortOrder order,
        out int comparisons,
        out int moves)
    {
        if (contacts == null)
        {
            throw new ArgumentNullException(nameof(contacts));
        }

        comparisons = 0;
        moves = 0;

        if (contacts.Length <= 1)
        {
            return;
        }

        Contact[] temporary = new Contact[contacts.Length];

        SortRecursive(
            contacts,
            temporary,
            0,
            contacts.Length - 1,
            field,
            order,
            ref comparisons,
            ref moves);
    }

    private static void SortRecursive(
        Contact[] contacts,
        Contact[] temporary,
        int left,
        int right,
        Field field,
        SortOrder order,
        ref int comparisons,
        ref int moves)
    {
        if (left >= right)
        {
            return;
        }

        int middle = left + (right - left) / 2;

        SortRecursive(
            contacts,
            temporary,
            left,
            middle,
            field,
            order,
            ref comparisons,
            ref moves);

        SortRecursive(
            contacts,
            temporary,
            middle + 1,
            right,
            field,
            order,
            ref comparisons,
            ref moves);

        Merge(
            contacts,
            temporary,
            left,
            middle,
            right,
            field,
            order,
            ref comparisons,
            ref moves);
    }

    private static void Merge(
        Contact[] contacts,
        Contact[] temporary,
        int left,
        int middle,
        int right,
        Field field,
        SortOrder order,
        ref int comparisons,
        ref int moves)
    {
        int i = left;
        int j = middle + 1;
        int k = left;

        while (i <= middle && j <= right)
        {
            string leftValue =
                ContactComparer.GetFieldValue(contacts[i], field);

            string rightValue =
                ContactComparer.GetFieldValue(contacts[j], field);

            comparisons++;

            int result =
                ContactComparer.Compare(leftValue, rightValue);

            bool takeLeft;

            if (order == SortOrder.Ascending)
            {
                takeLeft = result <= 0;
            }
            else
            {
                takeLeft = result >= 0;
            }

            if (takeLeft)
            {
                temporary[k] = contacts[i];
                i++;
            }
            else
            {
                temporary[k] = contacts[j];
                j++;
            }

            moves++;
            k++;
        }

        while (i <= middle)
        {
            temporary[k] = contacts[i];
            moves++;

            i++;
            k++;
        }

        while (j <= right)
        {
            temporary[k] = contacts[j];
            moves++;

            j++;
            k++;
        }

        for (int index = left; index <= right; index++)
        {
            contacts[index] = temporary[index];
        }
    }
}