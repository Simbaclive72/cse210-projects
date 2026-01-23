using System;
using System.Collections.Generic;


// Creativity:
// 1. Scripture library with random selection
// 2. Difficulty levels (easy/medium/hard)
// 3. Hint mode (reveals one hidden word)
// 4. Smart hiding (only hides visible words)


class Program
{
static void Main(string[] args)
{
List<Scripture> scriptures = new List<Scripture>
{
new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life"),
new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge him and he shall direct thy paths"),
new Scripture(new Reference("Psalm", 23, 1), "The Lord is my shepherd I shall not want")
};


Random rand = new Random();
Scripture scripture = scriptures[rand.Next(scriptures.Count)];


Console.Write("Choose difficulty (easy/medium/hard): ");
string difficulty = Console.ReadLine().ToLower();
int wordsToHide = difficulty == "hard" ? 5 : difficulty == "medium" ? 3 : 1;


while (!scripture.AllWordsHidden())
{
Console.Clear();
Console.WriteLine(scripture.GetDisplayText());
Console.WriteLine("\nPress ENTER to continue, type 'hint' for a hint, or 'quit' to exit:");
string input = Console.ReadLine().ToLower();


if (input == "quit") break;
if (input == "hint")
{
scripture.RevealOneWord();
}
else
{
scripture.HideRandomWords(wordsToHide);
}
}


Console.Clear();
Console.WriteLine(scripture.GetDisplayText());
Console.WriteLine("\nAll words hidden. Program finished.");
}
}