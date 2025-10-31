using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain;
        do
        {
            Console.WriteLine("Hello World! This is the Exercise3 Project.");

            
            Random random = new Random();
            int magic = random.Next(1, 101);
            int guess;
            int cont = 0;

            Console.WriteLine($"{magic}");
            do
            {
                Console.WriteLine("What is your guess?");
                guess = int.Parse(Console.ReadLine());

                if (guess < magic)
                {
                    Console.WriteLine("Select a higher number!");
                }
                else if (guess > magic)
                {
                    Console.WriteLine("Select a lower number!");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }

                cont++;

            } while (guess != magic);

            Console.WriteLine($"You tried to guess {cont} times.");

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().ToLower();

        } while (playAgain == "yes");

        Console.WriteLine("Thanks for playing! Goodbye!");
    }



}