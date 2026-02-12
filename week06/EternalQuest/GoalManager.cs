using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine($"\nYou have {_score} points.");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
            {
                Console.Write("Invalid input. Enter 1–6: ");
            }

            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoals(); break;
                case 3: SaveGoals(); break;
                case 4: LoadGoals(); break;
                case 5: RecordEvent(); break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nGoal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type? ");

        int type;
        while (!int.TryParse(Console.ReadLine(), out type) || type < 1 || type > 3)
        {
            Console.Write("Invalid input. Enter 1, 2, or 3: ");
        }

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points;
        while (!int.TryParse(Console.ReadLine(), out points) || points <= 0)
        {
            Console.Write("Enter a positive number: ");
        }

        if (type == 1)
            _goals.Add(new SimpleGoal(name, desc, points));
        else if (type == 2)
            _goals.Add(new EternalGoal(name, desc, points));
        else
        {
            Console.Write("Target count: ");
            int target;
            while (!int.TryParse(Console.ReadLine(), out target) || target <= 0)
                Console.Write("Enter a positive number: ");

            Console.Write("Bonus points: ");
            int bonus;
            while (!int.TryParse(Console.ReadLine(), out bonus) || bonus < 0)
                Console.Write("Enter 0 or greater: ");

            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetails()}");
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        ListGoals();
        Console.Write("Which goal did you accomplish? ");

        int index;
        while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > _goals.Count)
            Console.Write("Invalid selection: ");

        int points = _goals[index - 1].RecordEvent();
        _score += points;

        Console.WriteLine($"You earned {points} points!");
    }

    private void SaveGoals()
    {
        Console.Write("Filename: ");
        string file = Console.ReadLine();

        using (StreamWriter sw = new StreamWriter(file))
        {
            sw.WriteLine(_score);

            foreach (Goal g in _goals)
                sw.WriteLine(g.GetSaveString());
        }

        Console.WriteLine("Goals saved successfully.");
    }

    private void LoadGoals()
    {
        Console.Write("Filename: ");
        string file = Console.ReadLine();

        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(file);

        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");

            if (parts[0] == "Simple")
                _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])));
            else if (parts[0] == "Eternal")
                _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
            else
                _goals.Add(new ChecklistGoal(
                    parts[1], parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[5]),
                    int.Parse(parts[4])
                ));
        }

        Console.WriteLine("Goals loaded successfully.");
    }
}