using System.ComponentModel.DataAnnotations;

namespace TrimlightData.Models;
public class ScheduleDate
{
    [Range(1, 12)]
    public int Month { get; set; }
    [Range(1, 31)]
    public int Day { get; set; }
}

