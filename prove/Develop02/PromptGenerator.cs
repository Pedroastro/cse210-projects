public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "What moment today made me feel most grateful?",
        "Who did I help or support today, and how did it make me feel?",
        "What lesson did I learn today that I want to remember?",
        "How did I make someone else's day better today?",
        "What was the biggest challenge I overcame today?",
        "What am I most proud of accomplishing today?",
        "What inspired me today and why?",
        "How did I step outside my comfort zone today?",
        "What conversation had the most impact on me today?",
        "If I could relive one moment from today, what would it be and why?"
    };

    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int randomIndex = randomGenerator.Next(0,_prompts.Count);
        
        return _prompts[randomIndex];
    }
}