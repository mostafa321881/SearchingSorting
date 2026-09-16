using SearchingSorting.Models;
using SearchingSorting.Algorithms;
using SearchingSorting.Enums;

namespace SearchingSorting.Services;

public class BenchmarkRunner
{
    public static void Run(Contact[] contacts)
    {
        Console.WriteLine("=== BENCHMARK RESULTS ===");

        string firstNameTarget = contacts[0].FirstName;
        string middleNameTarget = contacts[contacts.Length / 2].FirstName;

        Contact? linearResult = LinearSearch.Search(
            contacts,
            firstNameTarget,
            Field.FirstName,
            out int linearComparisons
        );

        Console.WriteLine(
            $"Linear | Field: FirstName | Target: First | Found: {linearResult != null} | Search comparisons: {linearComparisons} | Sort comparisons: 0"
        );

        Contact? linearMiddle = LinearSearch.Search(
            contacts,
            middleNameTarget,
            Field.FirstName,
            out int linearMiddleComparisons
        );

        Console.WriteLine(
            $"Linear | Field: FirstName | Target: Middle | Found: {linearMiddle != null} | Search comparisons: {linearMiddleComparisons} | Sort comparisons: 0"
        );

        Contact? linearMissing = LinearSearch.Search(
            contacts,
            "ZZZ_NOT_FOUND",
            Field.FirstName,
            out int linearMissingComparisons
        );

        Console.WriteLine(
            $"Linear | Field: FirstName | Target: Missing | Found: {linearMissing != null} | Search comparisons: {linearMissingComparisons} | Sort comparisons: 0"
        );

        string firstLastNameTarget = contacts[0].LastName;
        string middleLastNameTarget = contacts[contacts.Length / 2].LastName;

        Contact? linearLastNameFirst = LinearSearch.Search(
            contacts,
            firstLastNameTarget,
            Field.LastName,
            out int linearLastNameFirstComparisons
        );

        Console.WriteLine(
            $"Linear | Field: LastName | Target: First | Found: {linearLastNameFirst != null} | Search comparisons: {linearLastNameFirstComparisons} | Sort comparisons: 0"
        );

        Contact? linearLastNameMiddle = LinearSearch.Search(
            contacts,
            middleLastNameTarget,
            Field.LastName,
            out int linearLastNameMiddleComparisons
        );

        Console.WriteLine(
            $"Linear | Field: LastName | Target: Middle | Found: {linearLastNameMiddle != null} | Search comparisons: {linearLastNameMiddleComparisons} | Sort comparisons: 0"
        );

        Contact? linearLastNameMissing = LinearSearch.Search(
            contacts,
            "ZZZ_NOT_FOUND",
            Field.LastName,
            out int linearLastNameMissingComparisons
        );

        Console.WriteLine(
            $"Linear | Field: LastName | Target: Missing | Found: {linearLastNameMissing != null} | Search comparisons: {linearLastNameMissingComparisons} | Sort comparisons: 0"
        );

        string firstMobileTarget = contacts[0].Mobile;
        string middleMobileTarget = contacts[contacts.Length / 2].Mobile;

        Contact? linearMobileFirst = LinearSearch.Search(
            contacts,
            firstMobileTarget,
            Field.Mobile,
            out int linearMobileFirstComparisons
        );

        Console.WriteLine(
            $"Linear | Field: Mobile | Target: First | Found: {linearMobileFirst != null} | Search comparisons: {linearMobileFirstComparisons} | Sort comparisons: 0"
        );

        Contact? linearMobileMiddle = LinearSearch.Search(
            contacts,
            middleMobileTarget,
            Field.Mobile,
            out int linearMobileMiddleComparisons
        );

        Console.WriteLine(
            $"Linear | Field: Mobile | Target: Middle | Found: {linearMobileMiddle != null} | Search comparisons: {linearMobileMiddleComparisons} | Sort comparisons: 0"
        );

        Contact? linearMobileMissing = LinearSearch.Search(
            contacts,
            "ZZZ_NOT_FOUND",
            Field.Mobile,
            out int linearMobileMissingComparisons
        );

        Console.WriteLine(
            $"Linear | Field: Mobile | Target: Missing | Found: {linearMobileMissing != null} | Search comparisons: {linearMobileMissingComparisons} | Sort comparisons: 0"
        );

        Contact[] firstNameAscending = (Contact[])contacts.Clone();

        PhonebookSorter.Sort(
            firstNameAscending,
            Field.FirstName,
            SortOrder.Ascending,
            out int firstNameAscendingSortComparisons
        );

        Contact? firstNameAscendingFirst = BinarySearch.Search(
            firstNameAscending,
            firstNameTarget,
            Field.FirstName,
            SortOrder.Ascending,
            out int firstNameAscendingFirstComparisons
        );

        Console.WriteLine(
            $"Binary | Field: FirstName | Order: Ascending | Target: First | Found: {firstNameAscendingFirst != null} | Search comparisons: {firstNameAscendingFirstComparisons} | Sort comparisons: {firstNameAscendingSortComparisons}"
        );

        Contact? firstNameAscendingMiddle = BinarySearch.Search(
            firstNameAscending,
            middleNameTarget,
            Field.FirstName,
            SortOrder.Ascending,
            out int firstNameAscendingMiddleComparisons
        );

        Console.WriteLine(
            $"Binary | Field: FirstName | Order: Ascending | Target: Middle | Found: {firstNameAscendingMiddle != null} | Search comparisons: {firstNameAscendingMiddleComparisons} | Sort comparisons: {firstNameAscendingSortComparisons}"
        );

        Contact? firstNameAscendingMissing = BinarySearch.Search(
            firstNameAscending,
            "ZZZ_NOT_FOUND",
            Field.FirstName,
            SortOrder.Ascending,
            out int firstNameAscendingMissingComparisons
        );

        Console.WriteLine(
            $"Binary | Field: FirstName | Order: Ascending | Target: Missing | Found: {firstNameAscendingMissing != null} | Search comparisons: {firstNameAscendingMissingComparisons} | Sort comparisons: {firstNameAscendingSortComparisons}"
        );

        Contact[] firstNameDescending = (Contact[])contacts.Clone();

        PhonebookSorter.Sort(
            firstNameDescending,
            Field.FirstName,
            SortOrder.Descending,
            out int firstNameDescendingSortComparisons
        );

        Contact? firstNameDescendingFirst = BinarySearch.Search(
            firstNameDescending,
            firstNameTarget,
            Field.FirstName,
            SortOrder.Descending,
            out int firstNameDescendingFirstComparisons
        );

        Console.WriteLine(
            $"Binary | Field: FirstName | Order: Descending | Target: First | Found: {firstNameDescendingFirst != null} | Search comparisons: {firstNameDescendingFirstComparisons} | Sort comparisons: {firstNameDescendingSortComparisons}"
        );

        Contact? firstNameDescendingMiddle = BinarySearch.Search(
            firstNameDescending,
            middleNameTarget,
            Field.FirstName,
            SortOrder.Descending,
            out int firstNameDescendingMiddleComparisons
        );

        Console.WriteLine(
            $"Binary | Field: FirstName | Order: Descending | Target: Middle | Found: {firstNameDescendingMiddle != null} | Search comparisons: {firstNameDescendingMiddleComparisons} | Sort comparisons: {firstNameDescendingSortComparisons}"
        );

        Contact? firstNameDescendingMissing = BinarySearch.Search(
            firstNameDescending,
            "ZZZ_NOT_FOUND",
            Field.FirstName,
            SortOrder.Descending,
            out int firstNameDescendingMissingComparisons
        );

        Console.WriteLine(
            $"Binary | Field: FirstName | Order: Descending | Target: Missing | Found: {firstNameDescendingMissing != null} | Search comparisons: {firstNameDescendingMissingComparisons} | Sort comparisons: {firstNameDescendingSortComparisons}"
        );

        Contact[] lastNameAscending = (Contact[])contacts.Clone();

        PhonebookSorter.Sort(
            lastNameAscending,
            Field.LastName,
            SortOrder.Ascending,
            out int lastNameAscendingSortComparisons
        );

        Contact? lastNameAscendingFirst = BinarySearch.Search(
            lastNameAscending,
            firstLastNameTarget,
            Field.LastName,
            SortOrder.Ascending,
            out int lastNameAscendingFirstComparisons
        );

        Console.WriteLine(
            $"Binary | Field: LastName | Order: Ascending | Target: First | Found: {lastNameAscendingFirst != null} | Search comparisons: {lastNameAscendingFirstComparisons} | Sort comparisons: {lastNameAscendingSortComparisons}"
        );

        Contact? lastNameAscendingMiddle = BinarySearch.Search(
            lastNameAscending,
            middleLastNameTarget,
            Field.LastName,
            SortOrder.Ascending,
            out int lastNameAscendingMiddleComparisons
        );

        Console.WriteLine(
            $"Binary | Field: LastName | Order: Ascending | Target: Middle | Found: {lastNameAscendingMiddle != null} | Search comparisons: {lastNameAscendingMiddleComparisons} | Sort comparisons: {lastNameAscendingSortComparisons}"
        );

        Contact? lastNameAscendingMissing = BinarySearch.Search(
            lastNameAscending,
            "ZZZ_NOT_FOUND",
            Field.LastName,
            SortOrder.Ascending,
            out int lastNameAscendingMissingComparisons
        );

        Console.WriteLine(
            $"Binary | Field: LastName | Order: Ascending | Target: Missing | Found: {lastNameAscendingMissing != null} | Search comparisons: {lastNameAscendingMissingComparisons} | Sort comparisons: {lastNameAscendingSortComparisons}"
        );

        Contact[] lastNameDescending = (Contact[])contacts.Clone();

        PhonebookSorter.Sort(
            lastNameDescending,
            Field.LastName,
            SortOrder.Descending,
            out int lastNameDescendingSortComparisons
        );

        Contact? lastNameDescendingFirst = BinarySearch.Search(
            lastNameDescending,
            firstLastNameTarget,
            Field.LastName,
            SortOrder.Descending,
            out int lastNameDescendingFirstComparisons
        );

        Console.WriteLine(
            $"Binary | Field: LastName | Order: Descending | Target: First | Found: {lastNameDescendingFirst != null} | Search comparisons: {lastNameDescendingFirstComparisons} | Sort comparisons: {lastNameDescendingSortComparisons}"
        );

        Contact? lastNameDescendingMiddle = BinarySearch.Search(
            lastNameDescending,
            middleLastNameTarget,
            Field.LastName,
            SortOrder.Descending,
            out int lastNameDescendingMiddleComparisons
        );

        Console.WriteLine(
            $"Binary | Field: LastName | Order: Descending | Target: Middle | Found: {lastNameDescendingMiddle != null} | Search comparisons: {lastNameDescendingMiddleComparisons} | Sort comparisons: {lastNameDescendingSortComparisons}"
        );

        Contact? lastNameDescendingMissing = BinarySearch.Search(
            lastNameDescending,
            "ZZZ_NOT_FOUND",
            Field.LastName,
            SortOrder.Descending,
            out int lastNameDescendingMissingComparisons
        );

        Console.WriteLine(
            $"Binary | Field: LastName | Order: Descending | Target: Missing | Found: {lastNameDescendingMissing != null} | Search comparisons: {lastNameDescendingMissingComparisons} | Sort comparisons: {lastNameDescendingSortComparisons}"
        );
        // Binary Search - Mobile - Ascending
Contact[] binaryMobileAscending = (Contact[])contacts.Clone();

PhonebookSorter.Sort(
    binaryMobileAscending,
    Field.Mobile,
    SortOrder.Ascending,
    out int mobileAscendingSortComparisons
);

string mobileFirstTarget = contacts[0].Mobile;
string mobileMiddleTarget = contacts[contacts.Length / 2].Mobile;

Contact? binaryMobileAscendingFirst = BinarySearch.Search(
    binaryMobileAscending,
    mobileFirstTarget,
    Field.Mobile,
    SortOrder.Ascending,
    out int mobileAscendingFirstComparisons
);

Console.WriteLine(
    $"Binary | Field: Mobile | Order: Ascending | Target: First | Found: {binaryMobileAscendingFirst != null} | Search comparisons: {mobileAscendingFirstComparisons} | Sort comparisons: {mobileAscendingSortComparisons}"
);

Contact? binaryMobileAscendingMiddle = BinarySearch.Search(
    binaryMobileAscending,
    mobileMiddleTarget,
    Field.Mobile,
    SortOrder.Ascending,
    out int mobileAscendingMiddleComparisons
);

Console.WriteLine(
    $"Binary | Field: Mobile | Order: Ascending | Target: Middle | Found: {binaryMobileAscendingMiddle != null} | Search comparisons: {mobileAscendingMiddleComparisons} | Sort comparisons: {mobileAscendingSortComparisons}"
);

Contact? binaryMobileAscendingMissing = BinarySearch.Search(
    binaryMobileAscending,
    "ZZZ_NOT_FOUND",
    Field.Mobile,
    SortOrder.Ascending,
    out int mobileAscendingMissingComparisons
);

Console.WriteLine(
    $"Binary | Field: Mobile | Order: Ascending | Target: Missing | Found: {binaryMobileAscendingMissing != null} | Search comparisons: {mobileAscendingMissingComparisons} | Sort comparisons: {mobileAscendingSortComparisons}"
);


// Binary Search - Mobile - Descending
Contact[] binaryMobileDescending = (Contact[])contacts.Clone();

PhonebookSorter.Sort(
    binaryMobileDescending,
    Field.Mobile,
    SortOrder.Descending,
    out int mobileDescendingSortComparisons
);

Contact? binaryMobileDescendingFirst = BinarySearch.Search(
    binaryMobileDescending,
    mobileFirstTarget,
    Field.Mobile,
    SortOrder.Descending,
    out int mobileDescendingFirstComparisons
);

Console.WriteLine(
    $"Binary | Field: Mobile | Order: Descending | Target: First | Found: {binaryMobileDescendingFirst != null} | Search comparisons: {mobileDescendingFirstComparisons} | Sort comparisons: {mobileDescendingSortComparisons}"
);

Contact? binaryMobileDescendingMiddle = BinarySearch.Search(
    binaryMobileDescending,
    mobileMiddleTarget,
    Field.Mobile,
    SortOrder.Descending,
    out int mobileDescendingMiddleComparisons
);

Console.WriteLine(
    $"Binary | Field: Mobile | Order: Descending | Target: Middle | Found: {binaryMobileDescendingMiddle != null} | Search comparisons: {mobileDescendingMiddleComparisons} | Sort comparisons: {mobileDescendingSortComparisons}"
);

Contact? binaryMobileDescendingMissing = BinarySearch.Search(
    binaryMobileDescending,
    "ZZZ_NOT_FOUND",
    Field.Mobile,
    SortOrder.Descending,
    out int mobileDescendingMissingComparisons
);

Console.WriteLine(
    $"Binary | Field: Mobile | Order: Descending | Target: Missing | Found: {binaryMobileDescendingMissing != null} | Search comparisons: {mobileDescendingMissingComparisons} | Sort comparisons: {mobileDescendingSortComparisons}"
);
    }
}