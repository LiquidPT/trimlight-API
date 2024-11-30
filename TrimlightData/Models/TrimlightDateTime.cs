using System.ComponentModel.DataAnnotations;

namespace TrimlightData.Models;
public class TrimlightDateTime : ScheduleTime
{
    [Range(0, 50)]
    public int Year { get; set; }
    [Range(1, 12)]
    public int Month { get; set; }
    [Range(1, 31)]
    public int Day { get; set; }
    public Weekday Weekday { get; set; }
    [Range(0, 59)]
    public int Seconds { get; set; }
}

public enum Weekday
{
    NotSet = 0,
    Sunday = 1,
    Monday = 2,
    Tuesday = 3,
    Wednesday = 4,
    Thursday = 5,
    Friday = 6,
    Saturday = 7
}

