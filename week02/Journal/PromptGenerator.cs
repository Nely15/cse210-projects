using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private Random random = new Random();

    public List<string> _prompts = new List<string>()
    {
        "I can see God's hand in my life when...",
        "When have you felt God's presence the most strongly in your life?",
        "How can maintaining faith change your daily approach to life's small difficulties?",
        "Describe a time when you felt your prayers were answered.",
        "How does your spiritual growth impact your life. What did you learn from it?",
        "What made you smile today?",
        "Did something in your day make you feel joyful? Why do you think that is and if you didn't, what can you do to make your day a bit more happy?"
    };

    public string GetRandomPrompt()
    {
        int number = random.Next(_prompts.Count);

        return _prompts[number];
    }
}