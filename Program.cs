using SearchingSorting.Tests;
using SearchingSorting.Services;

namespace SearchingSorting;

class Program
{
    static void Main()
    {
        AlgorithmTests.Run();

        CsvLoader loader = new CsvLoader();
        var contacts = loader.Load("Data/phonebook.csv");
        BenchmarkRunner.Run(contacts);
    }
}