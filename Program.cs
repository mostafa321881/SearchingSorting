using SearchingSorting.Services;
using SearchingSorting.Models;
using SearchingSorting.Algorithms;
using SearchingSorting.Enums;
namespace SearchingSorting;

class Program
{
    static void Main()
    {
        CsvLoader loader = new CsvLoader();
        Contact[] contacts = loader.Load("Data/phonebook.csv");
        Console.WriteLine($"Loaded contacts: {contacts.Length}");
        PhonebookSorter.Sort(contacts, Field.FirstName, SortOrder.Descending, out int sortComparisons);
        Console.WriteLine($"Sort comparisons: {sortComparisons}");
        Console.WriteLine($"First name after sorting: {contacts[0].FirstName}");
        Console.WriteLine($"Last name after sorting: {contacts[^1].FirstName}");

        Contact? found = LinearSearch.Search(
            contacts,
            "ZZZ_NOT_FOUND",
            Field.FirstName,
            out int comparisons
        );
        Console.WriteLine($"Comparisons: {comparisons}");

        if (found != null)
        {
            Console.WriteLine("Contact found!");
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }
        Contact? binaryFound = BinarySearch.Search(
            contacts,
            "ZZZ_NOT_FOUND",
            Field.FirstName,
            SortOrder.Descending,
            out int binaryComparisons
        );

        Console.WriteLine($"Binary comparisons: {binaryComparisons}");

        if (binaryFound != null)
        {
            Console.WriteLine($"Binary found: {binaryFound.FirstName}");
        }
        else
        {
            Console.WriteLine("Binary contact not found.");
        }
    }
}