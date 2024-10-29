using System.Text.Json;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected string _points;

    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public virtual void RecordEvent() 
    { 
        // Abstract method
    }
    
    public virtual bool IsCompleted() 
    { 
        return false; 
    }
    
    public virtual string GetDetailsString()
    {
        if (IsCompleted())
        {
            return $"[X] {_shortName} ({_description})";
        }
        else
        {
            return $"[ ] {_shortName} ({_description})";
        }
    }
    
    public virtual string GetStringRepresentation()
    {
        return JsonSerializer.Serialize(new
        {
            Type = GetType().Name,
            Name = _shortName,
            Description = _description,
            Points = _points
        });
    }

    public int GetPoints()
    {
        return int.Parse(_points);
    }

    public string GetShortName()
    {
        return _shortName;
    }
}