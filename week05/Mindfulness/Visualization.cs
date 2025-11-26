using System;
using System.Collections.Generic;
namespace MindfulnessProgram
{
    public class Visualization : Activity
    {
        private List<string> _scenes = new List<string>()
    {
        "a peaceful beach with soft waves",
        "a quiet forest with sunlight passing through the trees",
        "a calm mountain lake surrounded by tall peaks",
        "a warm cabin with a fireplace gently crackling",
        "a beautiful garden with colorful flowers",
        "a silent night sky full of stars"
    };

        public Visualization() : base("Visualization Activity",
            "This activity will help you calm your mind by imagining peaceful and relaxing scenes. Let your mind visualize as much detail as possible.")
        {
        }

        public void Start()
        {
            DisplayStartingMessage();

            Console.Clear();
            Console.WriteLine("Starting Visualization...\n");

            string scene = _scenes[_random.Next(_scenes.Count)];
            Console.WriteLine($"Picture yourself in the following place:\n");
            Console.WriteLine($"--- {scene} ---\n");
            Console.WriteLine("Close your eyes and try to imagine the sounds, smells, and sensations.");
            Spinner(4);

            DateTime start = DateTime.Now;
            DateTime end = start.AddSeconds(_duration);

            while (DateTime.Now < end)
            {
                Console.WriteLine("\nFocus on your breathing and the peaceful environment around you...");
                Spinner(5);
            }

            DisplayEndingMessage();
        }
    }
}