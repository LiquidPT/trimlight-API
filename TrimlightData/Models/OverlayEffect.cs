namespace TrimlightData.Models;
public class OverlayEffect
{
    public OverlayEffectType OverlayType { get; set; }
    public int TargetEffect { get; set; }
}

public enum OverlayEffectType
{
    Lightning = 0,
    Snow = 1
}
