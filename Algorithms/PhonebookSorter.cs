using SearchingSorting.Models;
using SearchingSorting.Enums;
using SearchingSorting.Services;
namespace SearchingSorting.Algorithms;
public class PhonebookSorter

{
    public static void Sort(Contact[] contacts, Field field, SortOrder order, out int comparisons)
    {
        comparisons = 0;
        for (int i = 1; i < contacts.Length; i++)
        {
            Contact current = contacts[i];
            int j = i - 1;
            while (j >= 0)
            {
                comparisons++;
                string previousValue = ContactComparer.GetFieldValue(contacts[j], field);
                string currentValue = ContactComparer.GetFieldValue(current, field);
                int result = ContactComparer.Compare(previousValue, currentValue);
                bool shouldMove;
                if (order == SortOrder.Ascending)
                {
                    shouldMove = result > 0;
                }
                else
                {
                    shouldMove = result < 0;
                }
                if (!shouldMove)
                {
                    break;
                }
                contacts[j + 1] = contacts[j];
                j--;
            }
            contacts[j + 1] = current;
        }
    }
}