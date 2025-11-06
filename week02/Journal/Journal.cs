using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries;


    public Journal()
    {
        _entries = new List<Entry>();
    }


    public void AddEntry(Entry e)
    {
        _entries.Add(e);
    }


    public IReadOnlyList<Entry> Entries => _entries.AsReadOnly();

    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            return;
        }
        Console.WriteLine("--- Journal Entries ---");
        foreach (var e in _entries)
        {
            Console.WriteLine(e.ToString());
        }
        Console.WriteLine("--- End of Journal ---");
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (var e in _entries)
            {
                sw.WriteLine(e.ToFileString());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
            throw new FileNotFoundException("File not found.", filename);


        string[] lines = File.ReadAllLines(filename);
        var newEntries = new List<Entry>();
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var e = Entry.FromFileString(line);
            newEntries.Add(e);
        }
        // Replace current entries with loaded ones (requirement: replace existing)
        _entries = newEntries;
    }

    public void Clear()
    {
        _entries.Clear();
    }
}