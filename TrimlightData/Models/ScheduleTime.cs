using System.ComponentModel.DataAnnotations;

namespace TrimlightData.Models;
public class ScheduleTime
{
    [Range(1, 24)]
    public int Hours { get; set; }
    [Range(0, 59)]
    public int Minutes { get; set; }
}

