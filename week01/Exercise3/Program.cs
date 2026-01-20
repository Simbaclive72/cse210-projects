using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        while (playAgain == "yes")
        {
            // User sets the magic number
            Console.Write("Enter the magic number (1-100): ");
            int magicNumber = int.Parse(Console.ReadLine());

            // Optional: Clear console so the guesser doesn't see it
            Console.Clear();

            int guess = 0;
            int guessCount = 0;

            // Guessing loop
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
            }

            // User guessed correctly
            Console.WriteLine("You guessed it!");
            Console.WriteLine($"It took you {guessCount} guesses.");

            // Play again?
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();

            Console.WriteLine(); // Add a blank line between rounds
        }
    }
}


