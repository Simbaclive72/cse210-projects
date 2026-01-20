using System;
using System.Collections.Generic; // Needed for Lists
using System.Linq; // Needed for some helper methods like Min, Max, Sort

class Program
{
    static void Main(string[] args)
    {
        // Step 1: Create a list to store the numbers
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Step 2: Ask the user for numbers until they enter 0
        while (true)
        {
            Console.Write("Enter number: ");
            int input = int.Parse(Console.ReadLine());

            if (input == 0) // Stop input when 0 is entered
            {
                break;
            }

            numbers.Add(input);
        }

        // Step 3: Core calculations

        // Check if list is not empty
        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        // Compute sum
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        // Compute average
        double average = (double)sum / numbers.Count;

        // Find maximum
        int max = numbers[0];
        foreach (int num in numbers)
        {
            if (num > max)
                max = num;
        }

        // Output core requirements
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        // --- Stretch Challenge ---

        // Find the smallest positive number
        int? smallestPositive = null;
        foreach (int num in numbers)
        {
            if (num > 0)
            {
                if (smallestPositive == null || num < smallestPositive)
                {
                    smallestPositive = num;
                }
            }
        }

        if (smallestPositive != null)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("No positive numbers were entered.");
        }

        // Sort the list
        numbers.Sort();

        // Display sorted list
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
