using System;
namespace MindfulnessProgram
{
    public class Breathing : Activity
    {
        public Breathing()
            : base("Breathing Activity",
                   "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        public void Start()
        {
            DisplayStartingMessage();

            Console.Clear();
            Console.WriteLine("--- Breathing Activity ---");
            Console.WriteLine("Get ready to begin...\n");

            DateTime start = DateTime.Now;
            DateTime end = start.AddSeconds(_duration);

            int inhale = 4;
            int exhale = 4;

            while (DateTime.Now < end)
            {
                Console.Write("Breathe in... ");
                int remaining = (int)Math.Ceiling((end - DateTime.Now).TotalSeconds);
                int secondsToCount = Math.Min(inhale, remaining);
                Countdown(secondsToCount);

                if (DateTime.Now >= end) break;

                Console.Write("Breathe out... ");
                remaining = (int)Math.Ceiling((end - DateTime.Now).TotalSeconds);
                secondsToCount = Math.Min(exhale, remaining);
                Countdown(secondsToCount);
            }

            DisplayEndingMessage();
        }
    }
}