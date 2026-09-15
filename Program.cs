using SearchingSorting.Services;
using SearchingSorting.Models;
using SearchingSorting.Algorithms;
using SearchingSorting.Enums;
namespace SearchingSorting;

class Program
{
    static void Main(string[] args)
    {
        CsvLoader loader = new CsvLoader();
        Contact[] contacts = loader.Load("Data/phonebook.csv");
        Console.WriteLine($"Loaded contacts: {contacts.Length}");
        Phonebook phonebook = new Phonebook(contacts);

        Contact? found = LinearSearch.Search(
            contacts,
            "\"ZZZ_NOT_FOUND\"",
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
    }
}