public class ChecklistGoal : Goal
{
    private int _target;
    private int _count;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _count = 0;
    }

    public override int RecordEvent()
    {
        _count++;
        int earned = _points;

        if (_count == _target)
            earned += _bonus;

        return earned;
    }

    public override string GetDetails()
    {
        string status = _count >= _target ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description}) -- Progress {_count}/{_target}";
    }

    public override string GetSaveString()
    {
        return $"Checklist|{_name}|{_description}|{_points}|{_bonus}|{_target}|{_count}";
    }
}