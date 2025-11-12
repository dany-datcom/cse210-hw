using System;


class Program
{
    // This Program class implements the console menu and ties the other classes together.
    // NOTE: To exceed requirements you could add JSON saving/loading or CSV safe-handling.
    // See the comment at the end describing optional enhancements made.


    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator prompts = new PromptGenerator();


        bool exit = false;
        while (!exit)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Add a custom prompt");
            Console.WriteLine("6. Show available prompts");
            Console.WriteLine("7. Clear journal");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");


            string choice = Console.ReadLine();
            Console.WriteLine();
            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, prompts);
                    break;
                case "2":
                    journal.Display();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    AddCustomPrompt(prompts);
                    break;
                case "6":
                    ShowPrompts(prompts);
                    break;
                case "7":
                    journal.Clear();
                    Console.WriteLine("Journal cleared.");
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }
    }

    static void WriteNewEntry(Journal journal, PromptGenerator prompts)
    {
        string prompt = prompts.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine("Write your response (single line). If you need multiple lines, separate them with \\n");
        Console.Write("Response: ");
        string response = Console.ReadLine() ?? string.Empty;
        string date = DateTime.Now.ToShortDateString();
        Entry e = new Entry(prompt, response, date);
        journal.AddEntry(e);
        Console.WriteLine("Entry added.");
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter filename to save to: ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Invalid filename.");
            return;
        }
        try
        {
            journal.SaveToFile(filename);
            Console.WriteLine($"Journal saved to {filename}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter filename to load from: ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Invalid filename.");
            return;
        }
        try
        {
            journal.LoadFromFile(filename);
            Console.WriteLine($"Journal loaded from {filename}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }

    static void AddCustomPrompt(PromptGenerator prompts)
    {
        Console.Write("Enter a new prompt to add: ");
        string p = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(p))
        {
            Console.WriteLine("Prompt cannot be empty.");
            return;
        }
        prompts.AddPrompt(p);
        Console.WriteLine("Prompt added.");
    }

    static void ShowPrompts(PromptGenerator prompts)
    {
        Console.WriteLine("Available prompts:");
        int i = 1;
        foreach (var p in prompts.Prompts)
        {
            Console.WriteLine($"{i++}. {p}");
        }
    }
}
/* Enhancements and notes (put this in Program.cs comments for your submission):
- Uses ~|~ as a safe separator and provides a simple escaping mechanism for that separator.
- Added ability to list and add custom prompts so users can tailor the app to themselves.
- Clear separation of concerns: Entry handles formatting, Journal manages collection and file IO,
PromptGenerator manages prompts.
- To go further (100% extras):
* Add JSON save/load (System.Text.Json) for richer data storage.
* Implement multi-line entry support and a simple text editor input.
* Save date/time as ISO format and store timezone info.
* Provide CSV export that handles quotes and commas correctly.
* Add tags, mood rating, or location (GPS) for each entry.
*/