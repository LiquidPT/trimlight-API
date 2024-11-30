namespace TrimlightData.Models;
public class Device
{
    public string DeviceId { get; set; }
    public string Name { get; set; }
    public SwitchState SwitchState { get; set; }
    public Connectivity Connectivity { get; set; }
    public DeviceState State { get; set; }
    public string FwVersionName { get; set; }
}
public enum SwitchState
{
    LightOff = 0,
    ManualMode = 1,
    TimerMode = 2
}

public enum Connectivity
{
    Offline = 0,
    Online = 1
}

public enum DeviceState
{
    Normal = 0,
    Upgrading = 1
}

