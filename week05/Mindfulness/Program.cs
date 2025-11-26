using System;
namespace MindfulnessProgram
{

    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;

            int countBreathing = 0;
            int countReflection = 0;
            int countListing = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("====== Mindfulness Main Menu ======");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Visualization Activity");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option (1–5): ");

                string input = Console.ReadLine();

                // Validate input (must be a number between 1 and 5)
                if (!int.TryParse(input, out option) || option < 1 || option > 5)
                {
                    Console.WriteLine("Please enter a valid number between 1 and 5.");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadLine();
                    continue;
                }

                switch (option)
                {
                    case 1:
                        var breathing = new Breathing();
                        breathing.Start();
                        countBreathing++;
                        break;

                    case 2:
                        var reflection = new Reflection();
                        reflection.Start();
                        countReflection++;
                        break;

                    case 3:
                        var listing = new Listing();
                        listing.Start();
                        countListing++;
                        break;

                    case 4:
                        var visualization = new Visualization();
                        visualization.Start();
                        break;

                    case 5:
                        Console.WriteLine("Exiting program...");
                        break;
                }

                if (option != 5)
                {
                    Console.WriteLine("\nPress ENTER to continue...");
                    Console.ReadLine();
                }

            } while (option != 5);

            // Session summary
            Console.WriteLine("\nSession Summary:");
            Console.WriteLine($"Breathing activities completed: {countBreathing}");
            Console.WriteLine($"Reflection activities completed: {countReflection}");
            Console.WriteLine($"Listing activities completed: {countListing}");
            Console.WriteLine("\nThank you for using the Mindfulness Program. Goodbye!");
        }
    }
}
