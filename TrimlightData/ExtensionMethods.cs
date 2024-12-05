using System.Security.Cryptography;
using System.Text;
using TrimlightData.Models;

namespace TrimlightData;
public static class ExtensionMethods
{
    public static TrimlightDateTime ToTrimlightDateTime(this DateTime dt)
    {
        return new TrimlightDateTime
        {
            Year = dt.Year,
            Month = dt.Month,
            Day = dt.Day,
            Hours = dt.Hour,
            Minutes = dt.Minute,
            Seconds = dt.Second,
            Weekday = (Weekday)((int)dt.DayOfWeek + 1)
        };
    }

    public static string HMACSHA256Hash(this string message, string key)
    {
        var encoding = Encoding.UTF8;
        var keyBytes = encoding.GetBytes(key);
        var messageBytes = encoding.GetBytes(message);
        var encryptedBytes = new HMACSHA256(keyBytes).ComputeHash(messageBytes);

        return Convert.ToBase64String(encryptedBytes);
    }
}
