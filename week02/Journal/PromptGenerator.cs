using System;
using System.Collections.Generic;


public class PromptGenerator
{
    private List<string> _prompts;
    private Random _random;


    public PromptGenerator()
    {
        _random = new Random();
        _prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What made me smile or laugh today?",
            "What is one small thing I accomplished today?",
            "What did I learn today?"
        };
    }


    public string GetRandomPrompt()
    {
        int idx = _random.Next(_prompts.Count);
        return _prompts[idx];
    }


    public void AddPrompt(string prompt)
    {
        if (!string.IsNullOrWhiteSpace(prompt))
            _prompts.Add(prompt);
    }


    public IReadOnlyList<string> Prompts => _prompts.AsReadOnly();
}