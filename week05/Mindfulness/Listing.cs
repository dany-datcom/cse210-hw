// ListingActivity
namespace MindfulnessProgram
{
    public class Listing : Activity
    {
        private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are your personal strengths?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

        private Queue<string> _promptQueue;

        public Listing() : base("Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
            _promptQueue = new Queue<string>(ShuffleList(_prompts));
        }

        public void Start()
        {
            DisplayStartingMessage();

            Console.Clear();
            Console.WriteLine("Get ready to begin...\n");

            string prompt = DequeueWithRefill(_promptQueue, _prompts);
            Console.WriteLine($"List as many responses as you can to the following prompt:\n\n--- {prompt} ---\n");
            Console.WriteLine("You will have a few seconds to think before you start listing.");
            Countdown(5);

            Console.WriteLine("\nStart listing! (press ENTER after each item)");

            DateTime start = DateTime.Now;
            DateTime end = start.AddSeconds(_duration);

            List<string> entries = new List<string>();

            while (DateTime.Now < end)
            {
                int remaining = (int)Math.Ceiling((end - DateTime.Now).TotalSeconds);
                Console.Write($"[{remaining}s left] > ");

                string item = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(item))
                {
                    entries.Add(item.Trim());
                }
            }

            Console.WriteLine($"\nYou listed {entries.Count} items. Great job!");
            Spinner(2);

            DisplayEndingMessage();
        }

        private string DequeueWithRefill(Queue<string> queue, List<string> source)
        {
            // FIXED: Now refills correctly
            if (queue.Count == 0)
            {
                foreach (var item in ShuffleList(source))
                {
                    queue.Enqueue(item);
                }
            }

            return queue.Dequeue();
        }

        private List<string> ShuffleList(List<string> list)
        {
            var copy = new List<string>(list);

            for (int i = copy.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);

                var tmp = copy[i];
                copy[i] = copy[j];
                copy[j] = tmp;
            }

            return copy;
        }
    }
}