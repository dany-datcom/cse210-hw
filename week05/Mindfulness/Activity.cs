using System;
using System.Threading;

namespace MindfulnessProgram
{
    public class Activity
    {
        private string _name;
        private string _description;
        protected int _duration;
        protected static Random _random = new Random();

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public virtual void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"--- {_name} ---\n");
            Console.WriteLine(_description);
            Console.Write("\nHow long, in seconds, would you like your session? ");

            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out _duration) && _duration > 0)
                {
                    break;
                }
                Console.Write("Invalid input. Please enter a positive number (seconds): ");
            }

            Console.WriteLine("\nGet ready...");
            Spinner(3);
        }

        public virtual void DisplayEndingMessage()
        {
            Console.WriteLine("\nWell done!!");
            Spinner(2);
            Console.WriteLine($"\nYou have completed {_duration} seconds of the activity.");
            Spinner(3);
        }

        protected void Spinner(int seconds)
        {
            string[] seq = { "|", "/", "-", "\\" };
            int index = 0;
            DateTime end = DateTime.Now.AddSeconds(seconds);

            while (DateTime.Now < end)
            {
                Console.Write(seq[index]);
                Thread.Sleep(250);
                Console.Write("\b \b");
                index = (index + 1) % seq.Length;
            }
        }

        protected void Countdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }
    }
}