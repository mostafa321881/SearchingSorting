using SearchingSorting.Models;
using SearchingSorting.Algorithms;
using SearchingSorting.Enums;

namespace SearchingSorting.Services;

public class BenchmarkRunner
{
    public static void Run(Contact[] contacts)
    {
        if (contacts == null)
        {
            throw new ArgumentNullException(nameof(contacts));
        }

        Console.WriteLine($"Loaded {contacts.Length} contacts from phonebook.csv");
        Console.WriteLine();

        RunLinearSearchBenchmarks(contacts);
        RunSortingBenchmarks(contacts);
        RunBinarySearchTests(contacts);
    }

    // ---------------------------------------------------------
    // 1. LINEAR SEARCH
    // ---------------------------------------------------------

    private static void RunLinearSearchBenchmarks(Contact[] contacts)
    {
        Console.WriteLine("--- 1. Linear search, unsorted ---");

        Console.WriteLine(
            $"{"field",-12} {"target",-20} {"matches",-10} {"comparisons",-12}");

        // Case 1: value held by first record
        PrintLinearResult(
            contacts,
            contacts[0].FirstName,
            Field.FirstName);

        // Case 2: value held by last record
        PrintLinearResult(
            contacts,
            contacts[^1].Mobile,
            Field.Mobile);

        // Case 3: absent surname
        PrintLinearResult(
            contacts,
            "ZZZ_NOT_FOUND",
            Field.LastName);

        // Case 4: absent mobile
        PrintLinearResult(
            contacts,
            "00000000",
            Field.Mobile);

        Console.WriteLine();
    }

    private static void PrintLinearResult(
        Contact[] contacts,
        string target,
        Field field)
    {
        Contact[] matches = LinearSearch.Search(
            contacts,
            target,
            field,
            out int comparisons);

        Console.WriteLine(
            $"{field,-12} {target,-20} {matches.Length,-10} {comparisons,-12}");
    }

    // ---------------------------------------------------------
    // 2. SORTING
    // ---------------------------------------------------------

    private static void RunSortingBenchmarks(Contact[] contacts)
    {
        Console.WriteLine("--- 2. Sorting, by LastName ascending ---");

        Console.WriteLine(
            $"{"algorithm",-16} {"shape",-18} {"comparisons",-14} {"moves",-10}");

        RunInsertionSortCases(contacts);
        RunMergeSortCases(contacts);

        Console.WriteLine();
    }

    private static void RunInsertionSortCases(Contact[] contacts)
    {
        // As supplied
        Contact[] asSupplied = (Contact[])contacts.Clone();

        PhonebookSorter.Sort(
            asSupplied,
            Field.LastName,
            SortOrder.Ascending,
            out int comparisons,
            out int moves);

        PrintSortResult(
            "InsertionSort",
            "as-supplied",
            comparisons,
            moves);

        // Already sorted
        Contact[] alreadySorted = (Contact[])asSupplied.Clone();

        PhonebookSorter.Sort(
            alreadySorted,
            Field.LastName,
            SortOrder.Ascending,
            out comparisons,
            out moves);

        PrintSortResult(
            "InsertionSort",
            "already-sorted",
            comparisons,
            moves);

        // Reverse sorted
        Contact[] reverseSorted = (Contact[])asSupplied.Clone();

        PhonebookSorter.Sort(
            reverseSorted,
            Field.LastName,
            SortOrder.Descending,
            out _,
            out _);

        PhonebookSorter.Sort(
            reverseSorted,
            Field.LastName,
            SortOrder.Ascending,
            out comparisons,
            out moves);

        PrintSortResult(
            "InsertionSort",
            "reverse-sorted",
            comparisons,
            moves);
    }

    private static void RunMergeSortCases(Contact[] contacts)
    {
        // As supplied
        Contact[] asSupplied = (Contact[])contacts.Clone();

        MergeSort.Sort(
            asSupplied,
            Field.LastName,
            SortOrder.Ascending,
            out int comparisons,
            out int moves);

        PrintSortResult(
            "MergeSort",
            "as-supplied",
            comparisons,
            moves);

        // Already sorted
        Contact[] alreadySorted = (Contact[])asSupplied.Clone();

        MergeSort.Sort(
            alreadySorted,
            Field.LastName,
            SortOrder.Ascending,
            out comparisons,
            out moves);

        PrintSortResult(
            "MergeSort",
            "already-sorted",
            comparisons,
            moves);

        // Reverse sorted
        Contact[] reverseSorted = (Contact[])asSupplied.Clone();

        MergeSort.Sort(
            reverseSorted,
            Field.LastName,
            SortOrder.Descending,
            out _,
            out _);

        MergeSort.Sort(
            reverseSorted,
            Field.LastName,
            SortOrder.Ascending,
            out comparisons,
            out moves);

        PrintSortResult(
            "MergeSort",
            "reverse-sorted",
            comparisons,
            moves);
    }

    private static void PrintSortResult(
        string algorithm,
        string shape,
        int comparisons,
        int moves)
    {
        Console.WriteLine(
            $"{algorithm,-16} {shape,-18} {comparisons,-14} {moves,-10}");
    }

    // ---------------------------------------------------------
    // 3. BINARY SEARCH - REQUIRED 8 TESTS
    // ---------------------------------------------------------

    private static void RunBinarySearchTests(Contact[] contacts)
    {
        Console.WriteLine("--- 3. Binary search tests ---");

        Console.WriteLine(
            $"{"#",-3} {"field",-12} {"target",-18} {"result",-12} {"comparisons",-12} {"status",-6}");

        // -----------------------------------------------------
        // TEST 1
        // Mobile: any number from the file
        // -----------------------------------------------------

        Contact[] byMobile = (Contact[])contacts.Clone();

        MergeSort.Sort(
            byMobile,
            Field.Mobile,
            SortOrder.Ascending,
            out _,
            out _);

        string mobileTarget =
            byMobile[byMobile.Length / 2].Mobile;

        int mobileIndex = BinarySearch.Search(
            byMobile,
            mobileTarget,
            Field.Mobile,
            out int mobileComparisons);

        bool test1 =
            mobileIndex >= 0 &&
            ContactComparer.Compare(
                byMobile[mobileIndex].Mobile,
                mobileTarget) == 0;

        PrintBinaryTest(
            1,
            Field.Mobile,
            mobileTarget,
            mobileIndex,
            mobileComparisons,
            test1);

        // -----------------------------------------------------
        // TEST 2
        // Mobile below smallest
        // -----------------------------------------------------

        int belowIndex = BinarySearch.Search(
            byMobile,
            "00000000",
            Field.Mobile,
            out int belowComparisons);

        PrintBinaryTest(
            2,
            Field.Mobile,
            "00000000",
            belowIndex,
            belowComparisons,
            belowIndex == -1);

        // -----------------------------------------------------
        // TEST 3
        // Mobile above largest
        // -----------------------------------------------------

        int aboveIndex = BinarySearch.Search(
            byMobile,
            "99999999",
            Field.Mobile,
            out int aboveComparisons);

        PrintBinaryTest(
            3,
            Field.Mobile,
            "99999999",
            aboveIndex,
            aboveComparisons,
            aboveIndex == -1);

        // -----------------------------------------------------
        // Sort by LastName for tests 4 and 5
        // -----------------------------------------------------

        Contact[] byLastName = (Contact[])contacts.Clone();

        MergeSort.Sort(
            byLastName,
            Field.LastName,
            SortOrder.Ascending,
            out _,
            out _);

        // -----------------------------------------------------
        // TEST 4
        // Duplicate LastName - must return lowest index
        // -----------------------------------------------------

        string duplicateLastName =
            FindDuplicateAfterFirstPosition(
                byLastName,
                Field.LastName);

        int lastNameIndex = BinarySearch.Search(
            byLastName,
            duplicateLastName,
            Field.LastName,
            out int lastNameComparisons);

        bool test4 =
            lastNameIndex >= 0 &&
            ContactComparer.Compare(
                byLastName[lastNameIndex].LastName,
                duplicateLastName) == 0 &&
            (lastNameIndex == 0 ||
             ContactComparer.Compare(
                 byLastName[lastNameIndex - 1].LastName,
                 duplicateLastName) != 0);

        PrintBinaryTest(
            4,
            Field.LastName,
            duplicateLastName,
            lastNameIndex,
            lastNameComparisons,
            test4);

        // Required proof
        if (lastNameIndex > 0)
        {
            string previousLastName =
                byLastName[lastNameIndex - 1].LastName;

            Console.WriteLine(
                $"    check: contacts[{lastNameIndex - 1}] = " +
                $"{previousLastName}, so index {lastNameIndex} is " +
                $"the first {duplicateLastName}: " +
                $"{(test4 ? "PASS" : "FAIL")}");
        }

        // -----------------------------------------------------
        // TEST 5
        // Absent LastName
        // -----------------------------------------------------

        int missingLastNameIndex = BinarySearch.Search(
            byLastName,
            "ZZZ_NOT_FOUND",
            Field.LastName,
            out int missingLastNameComparisons);

        PrintBinaryTest(
            5,
            Field.LastName,
            "ZZZ_NOT_FOUND",
            missingLastNameIndex,
            missingLastNameComparisons,
            missingLastNameIndex == -1);

        // -----------------------------------------------------
        // Sort by FirstName for test 6
        // -----------------------------------------------------

        Contact[] byFirstName = (Contact[])contacts.Clone();

        MergeSort.Sort(
            byFirstName,
            Field.FirstName,
            SortOrder.Ascending,
            out _,
            out _);

        // -----------------------------------------------------
        // TEST 6
        // FirstName - return lowest index
        // -----------------------------------------------------

        string firstNameTarget =
            FindDuplicateAfterFirstPosition(
                byFirstName,
                Field.FirstName);

        int firstNameIndex = BinarySearch.Search(
            byFirstName,
            firstNameTarget,
            Field.FirstName,
            out int firstNameComparisons);

        bool test6 =
            firstNameIndex >= 0 &&
            ContactComparer.Compare(
                byFirstName[firstNameIndex].FirstName,
                firstNameTarget) == 0 &&
            (firstNameIndex == 0 ||
             ContactComparer.Compare(
                 byFirstName[firstNameIndex - 1].FirstName,
                 firstNameTarget) != 0);

        PrintBinaryTest(
            6,
            Field.FirstName,
            firstNameTarget,
            firstNameIndex,
            firstNameComparisons,
            test6);

        // Required proof
        if (firstNameIndex > 0)
        {
            string previousFirstName =
                byFirstName[firstNameIndex - 1].FirstName;

            Console.WriteLine(
                $"    check: contacts[{firstNameIndex - 1}] = " +
                $"{previousFirstName}, so index {firstNameIndex} is " +
                $"the first {firstNameTarget}: " +
                $"{(test6 ? "PASS" : "FAIL")}");
        }

        // -----------------------------------------------------
        // TEST 7
        // Empty array
        // -----------------------------------------------------

        Contact[] empty = Array.Empty<Contact>();

        int emptyIndex = BinarySearch.Search(
            empty,
            "Anything",
            Field.FirstName,
            out int emptyComparisons);

        PrintBinaryTest(
            7,
            Field.FirstName,
            "empty array",
            emptyIndex,
            emptyComparisons,
            emptyIndex == -1);

        // -----------------------------------------------------
        // TEST 8
        // Single-element array
        // -----------------------------------------------------

        Contact[] single =
        {
            new Contact(
                "Only",
                "Person",
                "12345678",
                "2000-01-01",
                "Single Street",
                "Oslo")
        };

        int singleIndex = BinarySearch.Search(
            single,
            "Only",
            Field.FirstName,
            out int singleComparisons);

        PrintBinaryTest(
            8,
            Field.FirstName,
            "Only",
            singleIndex,
            singleComparisons,
            singleIndex == 0);

        Console.WriteLine();
    }

    private static void PrintBinaryTest(
        int testNumber,
        Field field,
        string target,
        int index,
        int comparisons,
        bool passed)
    {
        string result =
            index >= 0
                ? $"index {index}"
                : "-1";

        string status =
            passed
                ? "PASS"
                : "FAIL";

        Console.WriteLine(
            $"{testNumber,-3} {field,-12} {target,-18} " +
            $"{result,-12} {comparisons,-12} {status,-6}");
    }

    // Finds a duplicate whose first occurrence is after index 0.
    // This allows us to print the item immediately before it
    // as proof that Binary Search returned the lowest index.
    private static string FindDuplicateAfterFirstPosition(
        Contact[] contacts,
        Field field)
    {
        for (int i = 2; i < contacts.Length; i++)
        {
            string previous =
                ContactComparer.GetFieldValue(
                    contacts[i - 1],
                    field);

            string current =
                ContactComparer.GetFieldValue(
                    contacts[i],
                    field);

            if (ContactComparer.Compare(previous, current) == 0)
            {
                int firstIndex = i - 1;

                while (firstIndex > 0)
                {
                    string valueBefore =
                        ContactComparer.GetFieldValue(
                            contacts[firstIndex - 1],
                            field);

                    if (ContactComparer.Compare(
                            valueBefore,
                            current) != 0)
                    {
                        break;
                    }

                    firstIndex--;
                }

                if (firstIndex > 0)
                {
                    return current;
                }
            }
        }

        throw new InvalidOperationException(
            $"No suitable duplicate value found for {field}.");
    }
}