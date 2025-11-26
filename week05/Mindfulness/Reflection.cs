using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    public class Reflection : Activity
    {
        private List<string> _prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        private Queue<string> _promptQueue;
        private Queue<string> _questionQueue;

        public Reflection() : base("Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        {
            _promptQueue = new Queue<string>(ShuffleList(_prompts));
            _questionQueue = new Queue<string>(ShuffleList(_questions));
        }

        public void Start()
        {
            DisplayStartingMessage();

            Console.Clear();
            Console.WriteLine("--- Reflection Activity ---\n");
            Console.WriteLine("Get ready to begin...\n");

            string prompt = GetNextPrompt();
            Console.WriteLine("Consider the following prompt:\n");
            Console.WriteLine($"--- {prompt} ---\n");

            Console.WriteLine("When you have something in mind, press ENTER to continue.");
            Console.ReadLine();
            Console.WriteLine("Now reflect on each of the following questions:");
            Spinner(2);

            DateTime start = DateTime.Now;
            DateTime end = start.AddSeconds(_duration);

            while (DateTime.Now < end)
            {
                string question = GetNextQuestion();
                Console.WriteLine($"\n> {question}");

                int remaining = (int)(end - DateTime.Now).TotalSeconds;

                int spinnerTime = Math.Min(7, Math.Max(2, remaining));
                Spinner(spinnerTime);
            }

            DisplayEndingMessage();
        }

        // FIX: Now correctly refills queues
        private string GetNextPrompt()
        {
            if (_promptQueue.Count == 0)
                _promptQueue = new Queue<string>(ShuffleList(_prompts));

            return _promptQueue.Dequeue();
        }

        private string GetNextQuestion()
        {
            if (_questionQueue.Count == 0)
                _questionQueue = new Queue<string>(ShuffleList(_questions));

            return _questionQueue.Dequeue();
        }

        // Shuffle util
        private List<string> ShuffleList(List<string> list)
        {
            var copy = new List<string>(list);
            for (int i = copy.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                var temp = copy[i];
                copy[i] = copy[j];
                copy[j] = temp;
            }
            return copy;
        }
    }
}