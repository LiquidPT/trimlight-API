namespace TrimlightData.Models;

public class DailySchedule : Schedule
{
    public bool Enable { get; set; }
    public Repetition Repetition { get; set; }
}

public enum Repetition
{
    TodayOnly = 0,
    EveryDay = 1,
    Weekdays = 2,
    Weekends = 3
}

