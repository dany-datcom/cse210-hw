using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    // This class represents an entire scripture, including its reference and words.
    // It handles displaying the scripture and hiding words randomly.
    class Scripture
    {
        private ScriptureReference _reference;
        private List<Word> _words;
        private Random _random = new Random();
         // Constructor: initializes reference and splits the text into Word objects
        public Scripture(ScriptureReference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();
            string[] splitWords = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var w in splitWords)
                _words.Add(new Word(w));
        }

        
        public void Display()
        {
            Console.WriteLine(_reference);
            foreach (var word in _words)
                Console.Write(word + " ");
            Console.WriteLine("\n");
        }

        // Hides 'count' number of random words that are not already hidden
        public void HideRandomWords(int count = 1)
        {
            int hiddenCount = 0;
            while (hiddenCount < count)
            {
                int index = _random.Next(_words.Count);
                if (!_words[index].IsHidden())
                {
                    _words[index].Hide();
                    hiddenCount++;
                }
            }
        }

        // Returns true if all words in the scripture are hidden
        public bool IsFullyHidden()
        {
            foreach (var word in _words)
                if (!word.IsHidden())
                    return false;
            return true;
        }
    }
}