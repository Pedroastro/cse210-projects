public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public virtual double GetDistance()
    {
        return 0;
    }
    
    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min)- " +
               $"Distance {GetDistance():F1} km, Speed: {GetSpeed():F1} kph, " +
               $"Pace: {GetPace():F2} min per km";
    }

    protected int GetMinutes()
    {
        return _minutes;
    }
}