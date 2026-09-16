using SearchingSorting.Models;
using SearchingSorting.Algorithms;
using SearchingSorting.Enums;

namespace SearchingSorting.Tests;

public class AlgorithmTests
{
    public static void Run()
    {
        Contact[] contacts =
        {
            new Contact("Charlie", "Brown", "333", "2000-01-01", "Street 3", "Oslo"),
            new Contact("Alice", "Andersen", "111", "2000-01-02", "Street 1", "Bergen"),
            new Contact("Bob", "Berg", "222", "2000-01-03", "Street 2", "Trondheim")
        };

        Console.WriteLine("=== ALGORITHM TESTS ===");

        Contact? linearFound = LinearSearch.Search(
            contacts,
            "Alice",
            Field.FirstName,
            out int linearComparisons);

        Console.WriteLine(
            $"Linear found: {linearFound?.FirstName}, comparisons: {linearComparisons}");

        Contact? linearMissing = LinearSearch.Search(
            contacts,
            "ZZZ",
            Field.FirstName,
            out int linearMissingComparisons);

        Console.WriteLine(
            $"Linear missing: {linearMissing == null}, comparisons: {linearMissingComparisons}");

        PhonebookSorter.Sort(
            contacts,
            Field.FirstName,
            SortOrder.Ascending,
            out int ascendingSortComparisons);

        Console.WriteLine(
            $"Ascending: {contacts[0].FirstName}, {contacts[1].FirstName}, {contacts[2].FirstName}");

        Console.WriteLine(
            $"Ascending sort comparisons: {ascendingSortComparisons}");

        Contact? binaryAscending = BinarySearch.Search(
            contacts,
            "Bob",
            Field.FirstName,
            SortOrder.Ascending,
            out int binaryAscendingComparisons);

        Console.WriteLine(
            $"Binary ascending found: {binaryAscending?.FirstName}, comparisons: {binaryAscendingComparisons}");

        Contact? binaryMissing = BinarySearch.Search(
            contacts,
            "ZZZ",
            Field.FirstName,
            SortOrder.Ascending,
            out int binaryMissingComparisons);

        Console.WriteLine(
            $"Binary ascending missing: {binaryMissing == null}, comparisons: {binaryMissingComparisons}");

        PhonebookSorter.Sort(
            contacts,
            Field.FirstName,
            SortOrder.Descending,
            out int descendingSortComparisons);

        Console.WriteLine(
            $"Descending: {contacts[0].FirstName}, {contacts[1].FirstName}, {contacts[2].FirstName}");

        Console.WriteLine(
            $"Descending sort comparisons: {descendingSortComparisons}");

        Contact? binaryDescending = BinarySearch.Search(
            contacts,
            "Bob",
            Field.FirstName,
            SortOrder.Descending,
            out int binaryDescendingComparisons);

        Console.WriteLine(
            $"Binary descending found: {binaryDescending?.FirstName}, comparisons: {binaryDescendingComparisons}");

        Console.WriteLine("=== TESTS FINISHED ===");
    }
}