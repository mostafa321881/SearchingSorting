using SearchingSorting.Services;
using SearchingSorting.Models;

namespace SearchingSorting;

class Program
{
    static void Main()
    {
        try
        {
            CsvLoader loader = new CsvLoader();

            Contact[] contacts =
                loader.Load("Data/phonebook.csv");

            Phonebook phonebook =
                new Phonebook(contacts);

            BenchmarkRunner.Run(phonebook.GetContacts());
        }
        catch (Exception exception)
        {
            Console.WriteLine();
            Console.WriteLine("ERROR");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine(exception.Message);
        }
    }
}