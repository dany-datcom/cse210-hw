using System;

namespace ScriptureMemorizer
{
     // This class represents a single word in a scripture.
    // It handles whether the word is currently hidden or visible.
    class Word
    {
        private string _text;    // The actual word text
        private bool _hidden;     // True if the word is hidden
         // Constructor: initializes the word text and sets hidden to false
        public Word(string text)
        {
            _text = text;
            _hidden = false;
        }
        // Hides the word
        public void Hide()
        {
            _hidden = true;
        }
        // Returns whether the word is hidden
        public bool IsHidden()
        {
            return _hidden;
        }
        // Returns the word as a string: either the actual word or underscores
        public override string ToString()
        {   
            // If hidden, return underscores matching word length
            return _hidden ? new string('_', _text.Length) : _text;
        }
    }
}