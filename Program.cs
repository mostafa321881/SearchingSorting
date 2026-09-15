using SearchingSorting.Services;
using SearchingSorting.Models;
namespace SearchingSorting;

class Program
{
    static void Main(string[] args)
    {
        CsvLoader loader = new CsvLoader();
        Contact[] contacts = loader.Load("Data/phonebook.csv");
        Console.WriteLine($"Loaded contacts: {contacts.Length}");
        Phonebook phonebook = new Phonebook(contacts);

        Contact? found = phonebook.FindByFirstName("Geir");

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