using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nJournal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");

                    Console.Write("Response: ");
                    string response = Console.ReadLine();

                    Console.Write("Mood: ");
                    string mood = Console.ReadLine();

                    Console.Write("Tags: ");
                    string tags = Console.ReadLine();

                    Entry entry = new Entry(prompt, response, mood, tags);
                    journal.AddEntry(entry);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename: ");
                    journal.SaveToFile(Console.ReadLine());
                    Console.WriteLine("Saved.");
                    break;

                case "4":
                    Console.Write("Enter filename: ");
                    journal.LoadFromFile(Console.ReadLine());
                    Console.WriteLine("Loaded.");
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}

// Creativity:
// Added mood tracking, tags, and timestamps to each journal entry.
// Implemented file existence checks and confirmation messages.
// Used clean abstraction by separating responsibilities into multiple classes.
