using SearchingSorting.Models;

namespace SearchingSorting.Services;

public class CsvLoader
{
    public Contact[] Load(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        Contact[] contacts = new Contact[lines.Length - 1];
        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(',');
            Contact contact = new Contact(
                values[0],
                values[1],
                values[2],
                values[3],
                values[4],
                values[5]
            );
            contacts[i - 1] = contact;
        }
        return contacts;
    }
}