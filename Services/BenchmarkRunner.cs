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

        Console.WriteLine();
        Console.WriteLine("SEARCHING AND SORTING - RESULTS");
        Console.WriteLine("============================================================");
        Console.WriteLine($"Loaded {contacts.Length} contacts from phonebook.csv");

        RunLinearSearchBenchmarks(contacts);
        RunSortingBenchmarks(contacts);
        RunBinarySearchTests(contacts);

        Console.WriteLine("============================================================");
        Console.WriteLine("Program completed successfully.");
    }

    // ---------------------------------------------------------
    // 1. LINEAR SEARCH
    // ---------------------------------------------------------

    private static void RunLinearSearchBenchmarks(Contact[] contacts)
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("1. LINEAR SEARCH - UNSORTED DATA");
        Console.WriteLine("------------------------------------------------------------");

        Console.WriteLine(
            $"{"Field",-12} {"Target",-20} {"Matches",10} {"Comparisons",14}");

        Console.WriteLine(
            $"{"-----",-12} {"------",-20} {"-------",10} {"-----------",14}");

        // Required case 1: value held by the first record
        PrintLinearResult(
            contacts,
            contacts[0].FirstName,
            Field.FirstName);

        // Required case 2: value held by the last record
        PrintLinearResult(
            contacts,
            contacts[^1].Mobile,
            Field.Mobile);

        // Required case 3: absent surname
        PrintLinearResult(
            contacts,
            "ZZZ_NOT_FOUND",
            Field.LastName);

        // Required case 4: absent mobile
        PrintLinearResult(
            contacts,
            "00000000",
            Field.Mobile);
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
            $"{field,-12} {target,-20} {matches.Length,10} {comparisons,14}");
    }

    // ---------------------------------------------------------
    // 2. SORTING
    // ---------------------------------------------------------

    private static void RunSortingBenchmarks(Contact[] contacts)
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("2. SORTING - LASTNAME ASCENDING");
        Console.WriteLine("------------------------------------------------------------");

        Console.WriteLine(
            $"{"Algorithm",-16} {"Input",-18} {"Comparisons",14} {"Moves",10}");

        Console.WriteLine(
            $"{"---------",-16} {"-----",-18} {"-----------",14} {"-----",10}");

        RunInsertionSortCases(contacts);
        RunMergeSortCases(contacts);
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
            "Insertion Sort",
            "As supplied",
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
            "Insertion Sort",
            "Already sorted",
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
            "Insertion Sort",
            "Reverse sorted",
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
            "Merge Sort",
            "As supplied",
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
            "Merge Sort",
            "Already sorted",
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
            "Merge Sort",
            "Reverse sorted",
            comparisons,
            moves);
    }

    private static void PrintSortResult(
        string algorithm,
        string input,
        int comparisons,
        int moves)
    {
        Console.WriteLine(
            $"{algorithm,-16} {input,-18} {comparisons,14} {moves,10}");
    }

    // ---------------------------------------------------------
    // 3. BINARY SEARCH
    // ---------------------------------------------------------

    private static void RunBinarySearchTests(Contact[] contacts)
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("3. BINARY SEARCH - SORTED DATA");
        Console.WriteLine("------------------------------------------------------------");

        Console.WriteLine(
            $"{"Test",-5} {"Field",-11} {"Target",-16} " +
            $"{"Result",-11} {"Comparisons",11} {"Status",8}");

        Console.WriteLine(
            $"{"----",-5} {"-----",-11} {"------",-16} " +
            $"{"------",-11} {"-----------",11} {"------",8}");

        int passedTests = 0;

        // TEST 1 - Mobile number from file
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

        if (test1) passedTests++;

        // TEST 2 - Mobile below smallest
        int belowIndex = BinarySearch.Search(
            byMobile,
            "00000000",
            Field.Mobile,
            out int belowComparisons);

        bool test2 = belowIndex == -1;

        PrintBinaryTest(
            2,
            Field.Mobile,
            "00000000",
            belowIndex,
            belowComparisons,
            test2);

        if (test2) passedTests++;

        // TEST 3 - Mobile above largest
        int aboveIndex = BinarySearch.Search(
            byMobile,
            "99999999",
            Field.Mobile,
            out int aboveComparisons);

        bool test3 = aboveIndex == -1;

        PrintBinaryTest(
            3,
            Field.Mobile,
            "99999999",
            aboveIndex,
            aboveComparisons,
            test3);

        if (test3) passedTests++;

        // Sort by LastName
        Contact[] byLastName = (Contact[])contacts.Clone();

        MergeSort.Sort(
            byLastName,
            Field.LastName,
            SortOrder.Ascending,
            out _,
            out _);

        // TEST 4 - Duplicate LastName
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

        if (test4) passedTests++;

        if (lastNameIndex > 0)
        {
            string previousLastName =
                byLastName[lastNameIndex - 1].LastName;

            Console.WriteLine(
                $"      Previous value: {previousLastName,-15} " +
                $"First occurrence confirmed: {(test4 ? "PASS" : "FAIL")}");
        }

        // TEST 5 - Missing LastName
        int missingLastNameIndex = BinarySearch.Search(
            byLastName,
            "ZZZ_NOT_FOUND",
            Field.LastName,
            out int missingLastNameComparisons);

        bool test5 = missingLastNameIndex == -1;

        PrintBinaryTest(
            5,
            Field.LastName,
            "ZZZ_NOT_FOUND",
            missingLastNameIndex,
            missingLastNameComparisons,
            test5);

        if (test5) passedTests++;

        // Sort by FirstName
        Contact[] byFirstName = (Contact[])contacts.Clone();

        MergeSort.Sort(
            byFirstName,
            Field.FirstName,
            SortOrder.Ascending,
            out _,
            out _);

        // TEST 6 - FirstName, lowest index
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

        if (test6) passedTests++;

        if (firstNameIndex > 0)
        {
            string previousFirstName =
                byFirstName[firstNameIndex - 1].FirstName;

            Console.WriteLine(
                $"      Previous value: {previousFirstName,-15} " +
                $"First occurrence confirmed: {(test6 ? "PASS" : "FAIL")}");
        }

        // TEST 7 - Empty array
        Contact[] empty = Array.Empty<Contact>();

        int emptyIndex = BinarySearch.Search(
            empty,
            "Anything",
            Field.FirstName,
            out int emptyComparisons);

        bool test7 = emptyIndex == -1;

        PrintBinaryTest(
            7,
            Field.FirstName,
            "Empty array",
            emptyIndex,
            emptyComparisons,
            test7);

        if (test7) passedTests++;

        // TEST 8 - Single-element array
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

        bool test8 = singleIndex == 0;

        PrintBinaryTest(
            8,
            Field.FirstName,
            "Only",
            singleIndex,
            singleComparisons,
            test8);

        if (test8) passedTests++;

        Console.WriteLine();
        Console.WriteLine(
            $"Required binary search tests: {passedTests}/8 PASS");
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
                ? $"Index {index}"
                : "-1";

        string status =
            passed
                ? "PASS"
                : "FAIL";

        Console.WriteLine(
            $"{testNumber,-5} {field,-11} {target,-16} " +
            $"{result,-11} {comparisons,11} {status,8}");
    }

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