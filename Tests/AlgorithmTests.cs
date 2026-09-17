using SearchingSorting.Models;
using SearchingSorting.Algorithms;
using SearchingSorting.Enums;

namespace SearchingSorting.Tests;

public class AlgorithmTests
{
    public static void Run()
    {
        Console.WriteLine("=== ALGORITHM TESTS ===");

        Contact[] contacts =
        {
            new Contact("Charlie", "Brown", "333", "2000-01-01", "Street 3", "Oslo"),
            new Contact("Alice", "Andersen", "111", "2000-01-02", "Street 1", "Bergen"),
            new Contact("Bob", "Berg", "222", "2000-01-03", "Street 2", "Trondheim")
        };

        // Linear Search
        Contact[] linearFound = LinearSearch.Search(
            contacts,
            "Alice",
            Field.FirstName,
            out int linearComparisons);

        Console.WriteLine(
            $"Linear Search: {(linearFound.Length == 1 ? "PASS" : "FAIL")}");

        // Insertion Sort
        Contact[] insertionContacts = (Contact[])contacts.Clone();

        PhonebookSorter.Sort(
            insertionContacts,
            Field.FirstName,
            SortOrder.Ascending,
            out int insertionComparisons,
            out int insertionMoves);

        bool insertionCorrect =
            insertionContacts[0].FirstName == "Alice" &&
            insertionContacts[1].FirstName == "Bob" &&
            insertionContacts[2].FirstName == "Charlie";

        Console.WriteLine(
            $"Insertion Sort: {(insertionCorrect ? "PASS" : "FAIL")} " +
            $"(comparisons: {insertionComparisons}, moves: {insertionMoves})");

        // Merge Sort
        Contact[] mergeContacts = (Contact[])contacts.Clone();

        MergeSort.Sort(
            mergeContacts,
            Field.FirstName,
            SortOrder.Ascending,
            out int mergeComparisons,
            out int mergeMoves);

        bool mergeCorrect =
            mergeContacts[0].FirstName == "Alice" &&
            mergeContacts[1].FirstName == "Bob" &&
            mergeContacts[2].FirstName == "Charlie";

        Console.WriteLine(
            $"Merge Sort: {(mergeCorrect ? "PASS" : "FAIL")} " +
            $"(comparisons: {mergeComparisons}, moves: {mergeMoves})");

        // Binary Search
        int binaryIndex = BinarySearch.Search(
            mergeContacts,
            "Bob",
            Field.FirstName,
            out int binaryComparisons);

        bool binaryCorrect =
            binaryIndex == 1;

        Console.WriteLine(
            $"Binary Search: {(binaryCorrect ? "PASS" : "FAIL")} " +
            $"(index: {binaryIndex}, comparisons: {binaryComparisons})");

        // Binary Search - missing value
        int missingIndex = BinarySearch.Search(
            mergeContacts,
            "ZZZ",
            Field.FirstName,
            out int missingComparisons);

        Console.WriteLine(
            $"Binary missing: {(missingIndex == -1 ? "PASS" : "FAIL")} " +
            $"(index: {missingIndex}, comparisons: {missingComparisons})");

        // Empty array
        Contact[] empty = Array.Empty<Contact>();

        int emptyIndex = BinarySearch.Search(
            empty,
            "Alice",
            Field.FirstName,
            out int emptyComparisons);

        Console.WriteLine(
            $"Binary empty array: {(emptyIndex == -1 ? "PASS" : "FAIL")}");

        // Single-element array
        Contact[] single =
        {
            new Contact(
                "Alice",
                "Andersen",
                "111",
                "2000-01-02",
                "Street 1",
                "Bergen")
        };

        int singleIndex = BinarySearch.Search(
            single,
            "Alice",
            Field.FirstName,
            out int singleComparisons);

        Console.WriteLine(
            $"Binary single element: {(singleIndex == 0 ? "PASS" : "FAIL")}");

        Console.WriteLine("=== TESTS FINISHED ===");
        Console.WriteLine();
    }
}