using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of scriptures to randomly select from
            List<Scripture> scriptures = new List<Scripture>()
            {
                new Scripture(
                    new ScriptureReference("John", 3, 16),
                    "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."
                ),
                new Scripture(
                    new ScriptureReference("Proverbs", 3, 5-6),
                    "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."
                )
            };

            Random random = new Random();
            Scripture scripture = scriptures[random.Next(scriptures.Count)];

            Console.WriteLine("Welcome to Scripture Memorizer!");
            Console.WriteLine("Press Enter to hide words, or type 'quit' to exit.");

            while (true)
            {
                Console.Clear();
                scripture.Display();

                // End program if all words are hidden    
                if (scripture.IsFullyHidden())
                {
                    Console.WriteLine("All words are hidden. Well done!");
                    break;
                }

                string input = Console.ReadLine();
                if (input.Trim().ToLower() == "quit") // Exit if user types 'quit'
                    break;

                // Hide between 2 and 5 words randomly for added challenge
                scripture.HideRandomWords(random.Next(2, 6));
            }

            // Creativity / enhancements explained:
            // 1) Multiple scriptures available and selected randomly
            // 2) Hides 2-5 words per Enter key instead of just one
            // 3) Welcome message for user experience
        }
    }
}