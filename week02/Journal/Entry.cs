using System;

class Entry
{
    private string _date;
    private string _prompt;
    private string _response;
    private string _mood;
    private string _tags;

    // Constructor used when creating a NEW entry
    public Entry(string prompt, string response, string mood, string tags)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        _prompt = prompt;
        _response = response;
        _mood = mood;
        _tags = tags;
    }

    // Display entry to screen
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"Tags: {_tags}");
    }

    // Convert entry to ONE line for saving
    public string ToFileString()
    {
        return $"{_date}|{_prompt}|{_response}|{_mood}|{_tags}";
    }

    // Rebuild entry from saved line
    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split('|');

        Entry entry = new Entry(
            parts[1], // prompt
            parts[2], // response
            parts[3], // mood
            parts[4]  // tags
        );

        entry._date = parts[0]; // restore original date
        return entry;
    }
}
