namespace TrimlightData.Models;
public class Schedule
{
    public int Id { get; set; }
    public int EffectId { get; set; }
    public ScheduleTime StartTime { get; set; }
    public ScheduleTime EndTime { get; set; }
}

