namespace TrimlightData.Models;
public class DeviceDetails : Device
{
    public int ColorOrder { get; set; }
    public int Ic { get; set; }
    public Port[] Ports { get; set; }
    public Effect[] Effects { get; set; }
    public CombinedEffect CombinedEffect { get; set; }
    public DailySchedule[] Daily { get; set; }
    public CalendarSchedule[] Calendar { get; set; }
    public Effect CurrentEffect { get; set; }
    public OverlayEffect[] OverlayEffects { get; set; }
    public TrimlightDateTime ScheduleDateTime { get; set; }
}

public enum ColorOrder
{
    RGB = 0,
    RBG = 1,
    GRB = 2,
    GBR = 3,
    BRG = 4,
    BGR = 5
}

public enum Ic
{
    UCS1903 = 0,
    DMX512 = 1
}

