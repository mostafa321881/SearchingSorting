using SearchingSorting.Models;

namespace SearchingSorting.Services;

public class CsvLoader
{
    /// <summary>
    /// Loads contacts from a CSV file.
    /// The first line is treated as the header and skipped.
    /// Each data row must contain exactly six values.
    /// </summary>
    public Contact[] Load(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException(
                "The file path cannot be empty.",
                nameof(filePath));
        }

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException(
                $"The CSV file was not found: {filePath}");
        }

        string[] lines = File.ReadAllLines(filePath);

        if (lines.Length < 2)
        {
            throw new InvalidDataException(
                "The CSV file does not contain any contact data.");
        }

        Contact[] contacts = new Contact[lines.Length - 1];

        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(',');

            if (values.Length != 6)
            {
                throw new InvalidDataException(
                    $"Invalid CSV data on line {i + 1}. " +
                    "Expected exactly 6 values.");
            }

            Contact contact = new Contact(
                values[0].Trim(),
                values[1].Trim(),
                values[2].Trim(),
                values[3].Trim(),
                values[4].Trim(),
                values[5].Trim());

            contacts[i - 1] = contact;
        }

        return contacts;
    }
}