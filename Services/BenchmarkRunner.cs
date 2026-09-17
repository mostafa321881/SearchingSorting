using SearchingSorting.Models;
using SearchingSorting.Algorithms;
using SearchingSorting.Enums;

namespace SearchingSorting.Services;

public class BenchmarkRunner
{
    public static void Run(Contact[] contacts)
    {
        Console.WriteLine("=== BENCHMARK RESULTS ===");

        // -------------------------------------------------
        // LINEAR SEARCH - FIRST NAME
        // -------------------------------------------------

        string firstNameTarget = contacts[0].FirstName;
        string middleNameTarget = contacts[contacts.Length / 2].FirstName;

        Contact[] linearResult = LinearSearch.Search(
            contacts,
            firstNameTarget,
            Field.FirstName,
            out int linearComparisons);

        Console.WriteLine(
            $"Linear | Field: FirstName | Target: First | Found: {linearResult.Length > 0} | Matches: {linearResult.Length} | Search comparisons: {linearComparisons}");

        Contact[] linearMiddle = LinearSearch.Search(
            contacts,
            middleNameTarget,
            Field.FirstName,
            out int linearMiddleComparisons);

        Console.WriteLine(
            $"Linear | Field: FirstName | Target: Middle | Found: {linearMiddle.Length > 0} | Matches: {linearMiddle.Length} | Search comparisons: {linearMiddleComparisons}");

        Contact[] linearMissing = LinearSearch.Search(
            contacts,
            "ZZZ_NOT_FOUND",
            Field.FirstName,
            out int linearMissingComparisons);

        Console.WriteLine(
            $"Linear | Field: FirstName | Target: Missing | Found: {linearMissing.Length > 0} | Matches: {linearMissing.Length} | Search comparisons: {linearMissingComparisons}");

        // -------------------------------------------------
        // LINEAR SEARCH - LAST NAME
        // -------------------------------------------------

        string firstLastNameTarget = contacts[0].LastName;
        string middleLastNameTarget = contacts[contacts.Length / 2].LastName;

        Contact[] linearLastNameFirst = LinearSearch.Search(
            contacts,
            firstLastNameTarget,
            Field.LastName,
            out int linearLastNameFirstComparisons);

        Console.WriteLine(
            $"Linear | Field: LastName | Target: First | Found: {linearLastNameFirst.Length > 0} | Matches: {linearLastNameFirst.Length} | Search comparisons: {linearLastNameFirstComparisons}");

        Contact[] linearLastNameMiddle = LinearSearch.Search(
            contacts,
            middleLastNameTarget,
            Field.LastName,
            out int linearLastNameMiddleComparisons);

        Console.WriteLine(
            $"Linear | Field: LastName | Target: Middle | Found: {linearLastNameMiddle.Length > 0} | Matches: {linearLastNameMiddle.Length} | Search comparisons: {linearLastNameMiddleComparisons}");

        Contact[] linearLastNameMissing = LinearSearch.Search(
            contacts,
            "ZZZ_NOT_FOUND",
            Field.LastName,
            out int linearLastNameMissingComparisons);

        Console.WriteLine(
            $"Linear | Field: LastName | Target: Missing | Found: {linearLastNameMissing.Length > 0} | Matches: {linearLastNameMissing.Length} | Search comparisons: {linearLastNameMissingComparisons}");

        // -------------------------------------------------
        // LINEAR SEARCH - MOBILE
        // -------------------------------------------------

        string firstMobileTarget = contacts[0].Mobile;
        string middleMobileTarget = contacts[contacts.Length / 2].Mobile;

        Contact[] linearMobileFirst = LinearSearch.Search(
            contacts,
            firstMobileTarget,
            Field.Mobile,
            out int linearMobileFirstComparisons);

        Console.WriteLine(
            $"Linear | Field: Mobile | Target: First | Found: {linearMobileFirst.Length > 0} | Matches: {linearMobileFirst.Length} | Search comparisons: {linearMobileFirstComparisons}");

        Contact[] linearMobileMiddle = LinearSearch.Search(
            contacts,
            middleMobileTarget,
            Field.Mobile,
            out int linearMobileMiddleComparisons);

        Console.WriteLine(
            $"Linear | Field: Mobile | Target: Middle | Found: {linearMobileMiddle.Length > 0} | Matches: {linearMobileMiddle.Length} | Search comparisons: {linearMobileMiddleComparisons}");

        Contact[] linearMobileMissing = LinearSearch.Search(
            contacts,
            "ZZZ_NOT_FOUND",
            Field.Mobile,
            out int linearMobileMissingComparisons);

        Console.WriteLine(
            $"Linear | Field: Mobile | Target: Missing | Found: {linearMobileMissing.Length > 0} | Matches: {linearMobileMissing.Length} | Search comparisons: {linearMobileMissingComparisons}");

        // -------------------------------------------------
        // BINARY SEARCH - FIRST NAME ASCENDING
        // -------------------------------------------------

        Contact[] firstNameAscending = (Contact[])contacts.Clone();

        PhonebookSorter.Sort(
            firstNameAscending,
            Field.FirstName,
            SortOrder.Ascending,
            out int firstNameAscendingSortComparisons,
            out int firstNameAscendingSortMoves);

        Contact? firstNameAscendingFirst = BinarySearch.Search(
            firstNameAscending,
            firstNameTarget,
            Field.FirstName,
            SortOrder.Ascending,
            out int firstNameAscendingFirstComparisons);

        Console.WriteLine(
            $"Binary | Field: FirstName | Order: Ascending | Target: First | Found: {firstNameAscendingFirst != null} | Search comparisons: {firstNameAscendingFirstComparisons} | Sort comparisons: {firstNameAscendingSortComparisons} | Moves: {firstNameAscendingSortMoves}");

        Contact? firstNameAscendingMiddle = BinarySearch.Search(
            firstNameAscending,
            middleNameTarget,
            Field.FirstName,
            SortOrder.Ascending,
            out int firstNameAscendingMiddleComparisons);

        Console.WriteLine(
            $"Binary | Field: FirstName | Order: Ascending | Target: Middle | Found: {firstNameAscendingMiddle != null} | Search comparisons: {firstNameAscendingMiddleComparisons}");

        Contact? firstNameAscendingMissing = BinarySearch.Search(
            firstNameAscending,
            "ZZZ_NOT_FOUND",
            Field.FirstName,
            SortOrder.Ascending,
            out int firstNameAscendingMissingComparisons);

        Console.WriteLine(
            $"Binary | Field: FirstName | Order: Ascending | Target: Missing | Found: {firstNameAscendingMissing != null} | Search comparisons: {firstNameAscendingMissingComparisons}");

        // -------------------------------------------------
        // BINARY SEARCH - FIRST NAME DESCENDING
        // -------------------------------------------------

        Contact[] firstNameDescending = (Contact[])contacts.Clone();

        PhonebookSorter.Sort(
            firstNameDescending,
            Field.FirstName,
            SortOrder.Descending,
            out int firstNameDescendingSortComparisons,
            out int firstNameDescendingSortMoves);

        Contact? firstNameDescendingFirst = BinarySearch.Search(
            firstNameDescending,
            firstNameTarget,
            Field.FirstName,
            SortOrder.Descending,
            out int firstNameDescendingFirstComparisons);

        Console.WriteLine(
            $"Binary | Field: FirstName | Order: Descending | Target: First | Found: {firstNameDescendingFirst != null} | Search comparisons: {firstNameDescendingFirstComparisons} | Sort comparisons: {firstNameDescendingSortComparisons} | Moves: {firstNameDescendingSortMoves}");

        Contact? firstNameDescendingMiddle = BinarySearch.Search(
            firstNameDescending,
            middleNameTarget,
            Field.FirstName,
            SortOrder.Descending,
            out int firstNameDescendingMiddleComparisons);

        Console.WriteLine(
            $"Binary | Field: FirstName | Order: Descending | Target: Middle | Found: {firstNameDescendingMiddle != null} | Search comparisons: {firstNameDescendingMiddleComparisons}");

        Contact? firstNameDescendingMissing = BinarySearch.Search(
            firstNameDescending,
            "ZZZ_NOT_FOUND",
            Field.FirstName,
            SortOrder.Descending,
            out int firstNameDescendingMissingComparisons);

        Console.WriteLine(
            $"Binary | Field: FirstName | Order: Descending | Target: Missing | Found: {firstNameDescendingMissing != null} | Search comparisons: {firstNameDescendingMissingComparisons}");

        // -------------------------------------------------
        // BINARY SEARCH - LAST NAME ASCENDING
        // -------------------------------------------------

        Contact[] lastNameAscending = (Contact[])contacts.Clone();

        PhonebookSorter.Sort(
            lastNameAscending,
            Field.LastName,
            SortOrder.Ascending,
            out int lastNameAscendingSortComparisons,
            out int lastNameAscendingSortMoves);

        Contact? lastNameAscendingFirst = BinarySearch.Search(
            lastNameAscending,
            firstLastNameTarget,
            Field.LastName,
            SortOrder.Ascending,
            out int lastNameAscendingFirstComparisons);

        Console.WriteLine(
            $"Binary | Field: LastName | Order: Ascending | Target: First | Found: {lastNameAscendingFirst != null} | Search comparisons: {lastNameAscendingFirstComparisons} | Sort comparisons: {lastNameAscendingSortComparisons} | Moves: {lastNameAscendingSortMoves}");

        Contact? lastNameAscendingMiddle = BinarySearch.Search(
            lastNameAscending,
            middleLastNameTarget,
            Field.LastName,
            SortOrder.Ascending,
            out int lastNameAscendingMiddleComparisons);

        Console.WriteLine(
            $"Binary | Field: LastName | Order: Ascending | Target: Middle | Found: {lastNameAscendingMiddle != null} | Search comparisons: {lastNameAscendingMiddleComparisons}");

        Contact? lastNameAscendingMissing = BinarySearch.Search(
            lastNameAscending,
            "ZZZ_NOT_FOUND",
            Field.LastName,
            SortOrder.Ascending,
            out int lastNameAscendingMissingComparisons);

        Console.WriteLine(
            $"Binary | Field: LastName | Order: Ascending | Target: Missing | Found: {lastNameAscendingMissing != null} | Search comparisons: {lastNameAscendingMissingComparisons}");

        // -------------------------------------------------
        // BINARY SEARCH - LAST NAME DESCENDING
        // -------------------------------------------------

        Contact[] lastNameDescending = (Contact[])contacts.Clone();

        PhonebookSorter.Sort(
            lastNameDescending,
            Field.LastName,
            SortOrder.Descending,
            out int lastNameDescendingSortComparisons,
            out int lastNameDescendingSortMoves);

        Contact? lastNameDescendingFirst = BinarySearch.Search(
            lastNameDescending,
            firstLastNameTarget,
            Field.LastName,
            SortOrder.Descending,
            out int lastNameDescendingFirstComparisons);

        Console.WriteLine(
            $"Binary | Field: LastName | Order: Descending | Target: First | Found: {lastNameDescendingFirst != null} | Search comparisons: {lastNameDescendingFirstComparisons} | Sort comparisons: {lastNameDescendingSortComparisons} | Moves: {lastNameDescendingSortMoves}");

        Contact? lastNameDescendingMiddle = BinarySearch.Search(
            lastNameDescending,
            middleLastNameTarget,
            Field.LastName,
            SortOrder.Descending,
            out int lastNameDescendingMiddleComparisons);

        Console.WriteLine(
            $"Binary | Field: LastName | Order: Descending | Target: Middle | Found: {lastNameDescendingMiddle != null} | Search comparisons: {lastNameDescendingMiddleComparisons}");

        Contact? lastNameDescendingMissing = BinarySearch.Search(
            lastNameDescending,
            "ZZZ_NOT_FOUND",
            Field.LastName,
            SortOrder.Descending,
            out int lastNameDescendingMissingComparisons);

        Console.WriteLine(
            $"Binary | Field: LastName | Order: Descending | Target: Missing | Found: {lastNameDescendingMissing != null} | Search comparisons: {lastNameDescendingMissingComparisons}");

        // -------------------------------------------------
        // BINARY SEARCH - MOBILE ASCENDING
        // -------------------------------------------------

        Contact[] mobileAscending = (Contact[])contacts.Clone();

        PhonebookSorter.Sort(
            mobileAscending,
            Field.Mobile,
            SortOrder.Ascending,
            out int mobileAscendingSortComparisons,
            out int mobileAscendingSortMoves);

        Contact? mobileAscendingFirst = BinarySearch.Search(
            mobileAscending,
            firstMobileTarget,
            Field.Mobile,
            SortOrder.Ascending,
            out int mobileAscendingFirstComparisons);

        Console.WriteLine(
            $"Binary | Field: Mobile | Order: Ascending | Target: First | Found: {mobileAscendingFirst != null} | Search comparisons: {mobileAscendingFirstComparisons} | Sort comparisons: {mobileAscendingSortComparisons} | Moves: {mobileAscendingSortMoves}");

        Contact? mobileAscendingMiddle = BinarySearch.Search(
            mobileAscending,
            middleMobileTarget,
            Field.Mobile,
            SortOrder.Ascending,
            out int mobileAscendingMiddleComparisons);

        Console.WriteLine(
            $"Binary | Field: Mobile | Order: Ascending | Target: Middle | Found: {mobileAscendingMiddle != null} | Search comparisons: {mobileAscendingMiddleComparisons}");

        Contact? mobileAscendingMissing = BinarySearch.Search(
            mobileAscending,
            "ZZZ_NOT_FOUND",
            Field.Mobile,
            SortOrder.Ascending,
            out int mobileAscendingMissingComparisons);

        Console.WriteLine(
            $"Binary | Field: Mobile | Order: Ascending | Target: Missing | Found: {mobileAscendingMissing != null} | Search comparisons: {mobileAscendingMissingComparisons}");

        // -------------------------------------------------
        // BINARY SEARCH - MOBILE DESCENDING
        // -------------------------------------------------

        Contact[] mobileDescending = (Contact[])contacts.Clone();

        PhonebookSorter.Sort(
            mobileDescending,
            Field.Mobile,
            SortOrder.Descending,
            out int mobileDescendingSortComparisons,
            out int mobileDescendingSortMoves);

        Contact? mobileDescendingFirst = BinarySearch.Search(
            mobileDescending,
            firstMobileTarget,
            Field.Mobile,
            SortOrder.Descending,
            out int mobileDescendingFirstComparisons);

        Console.WriteLine(
            $"Binary | Field: Mobile | Order: Descending | Target: First | Found: {mobileDescendingFirst != null} | Search comparisons: {mobileDescendingFirstComparisons} | Sort comparisons: {mobileDescendingSortComparisons} | Moves: {mobileDescendingSortMoves}");

        Contact? mobileDescendingMiddle = BinarySearch.Search(
            mobileDescending,
            middleMobileTarget,
            Field.Mobile,
            SortOrder.Descending,
            out int mobileDescendingMiddleComparisons);

        Console.WriteLine(
            $"Binary | Field: Mobile | Order: Descending | Target: Middle | Found: {mobileDescendingMiddle != null} | Search comparisons: {mobileDescendingMiddleComparisons}");

        Contact? mobileDescendingMissing = BinarySearch.Search(
            mobileDescending,
            "ZZZ_NOT_FOUND",
            Field.Mobile,
            SortOrder.Descending,
            out int mobileDescendingMissingComparisons);

        Console.WriteLine(
            $"Binary | Field: Mobile | Order: Descending | Target: Missing | Found: {mobileDescendingMissing != null} | Search comparisons: {mobileDescendingMissingComparisons}");
    }
}