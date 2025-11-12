using System;

namespace ScriptureMemorizer
{
    // This class represents a scripture reference (e.g., John 3:16)
    // It can handle a single verse or a range of verses.
    class ScriptureReference
    {
        private string _book;// The book name
        private int _startVerse;// Starting verse
        private int _endVerse;// Ending verse (same as start if single verse)

        // Constructor for a single verse
        public ScriptureReference(string book, int verse)
        {
            _book = book;
            _startVerse = verse;
            _endVerse = verse;
        }

        // Constructor for a verse range
        public ScriptureReference(string book, int startVerse, int endVerse)
        {
            _book = book;
            _startVerse = startVerse;
            _endVerse = endVerse;
        }
        // Returns the reference as a string
        public override string ToString()
        {
            return _startVerse == _endVerse 
                ? $"{_book} {_startVerse}" // Single verse
                : $"{_book} {_startVerse}-{_endVerse}"; // Verse range
        }
    }
}