using System;

public class Entry
{   
    // Abstraction: keep fields private and expose only what is necessary via properties
    private string _prompt;
    private string _response;
    private string _date;


    public string Prompt { get { return _prompt; } }
    public string Response { get { return _response; } }
    public string Date { get { return _date; } }


    public Entry(string prompt, string response, string date)
    {
        _prompt = prompt;
        _response = response;
        _date = date;
    }

    // Return a single-line representation safe for saving (uses ~|~ as separator)
    public string ToFileString()
    {
        return $"{Escape(_prompt)}~|~{Escape(_response)}~|~{_date}";
    }


    // Create Entry from a line in the file
    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split(new string[] { "~|~" }, StringSplitOptions.None);
        if (parts.Length < 3)
        {
            throw new FormatException("Invalid entry line format.");
        }
        string prompt = Unescape(parts[0]);
        string response = Unescape(parts[1]);
        string date = parts[2];
        return new Entry(prompt, response, date);
    }

    // Very simple escaping to avoid breaking our separator    
    private static string Escape(string s)
    {
        return s.Replace("~|~", "~||~");
    }


    private static string Unescape(string s)
    {
        return s.Replace("~||~", "~|~");
    }


    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

