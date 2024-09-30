using System.IO;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"Date: {entry._date} - Prompt: {entry._promptText}");
                outputFile.WriteLine($"Entry: {entry._entryText}");
                outputFile.WriteLine();
            }
        }
    }

    public void LoadFromFile(string file)
    {
        string[] lines = System.IO.File.ReadAllLines(file);

        string date = "";
        string promptText = "";
        string entryText = "";
        foreach (string line in lines)
        {
            if (line == "")
            {
                Entry entry = new Entry();
                entry._date = date;
                entry._promptText = promptText;
                entry._entryText = entryText;
                this.AddEntry(entry);

                date = "";
                promptText = "";
                entryText = "";
            }
            else if (line.Substring(0, 4) == "Date")
            {
                string[] parts = line.Split("-");

                date = parts[0].Substring(6).Trim();
                promptText = parts[1].Substring(9).Trim();
            }
            else if (line.Substring(0, 5) == "Entry")
            {
                entryText = line.Substring(7);
            }
        }
    }
}