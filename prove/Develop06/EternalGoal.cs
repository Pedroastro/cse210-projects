public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points) 
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Eternal goals are never complete
    }

    public override bool IsCompleted()
    {
        return false; // Eternal goals are never complete
    }

    public override string GetStringRepresentation()
    {
        return base.GetStringRepresentation();
    }
}