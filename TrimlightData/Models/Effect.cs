using System.ComponentModel.DataAnnotations;

namespace TrimlightData.Models;
public class Effect
{
    public int Id { get; set; }
    public Category Category { get; set; }
    [Range(0, 179)]
    public int Mode { get; set; }
    [Range(0, 255)]
    public int Speed { get; set; }
    [Range(0, 255)]
    public int Brightness { get; set; }
    [Range(1, 90)]
    public int PixelLen { get; set; }
    public bool Reverse { get; set; }
    public Pixel[]? Pixels { get; set; }
}

public enum Category
{
    BuiltIn = 0,
    Custom = 1
}

