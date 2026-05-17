using System;
using System.Collections.Generic;
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

    public void DisplayByMood(string mood)
    {
        bool found = false;

        foreach (Entry entry in _entries)
        {
            if (entry._mood.ToLower() == mood.ToLower())
            {
                entry.Display();
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("No entries found with that mood.");
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}|{entry._mood}");
            }
        }
        Console.WriteLine("Journal saved.");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }
        
        string[] lines = File.ReadAllLines(file);

        _entries.Clear();

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            if (parts.Length >= 4)
            {
                Entry newEntry = new Entry();

                newEntry._date = parts[0];
                newEntry._promptText = parts[1];
                newEntry._entryText = parts[2];
                newEntry._mood = parts[3];

                _entries.Add(newEntry);
            }
    
        }

        Console.WriteLine("Journal loaded.");
    }
}