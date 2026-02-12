using System;

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
// EXCEEDING REQUIREMENTS:
// - Implemented full polymorphism using an abstract base class (Goal) and overridden methods in all derived classes.
// - Added full input validation using TryParse to prevent runtime crashes from invalid user input.
// - Implemented defensive file handling when loading and saving goals.
// - Improved user experience with clean menus, formatted output, and helpful validation messages.