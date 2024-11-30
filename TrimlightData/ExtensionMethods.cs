using System.Security.Cryptography;
using System.Text;
using TrimlightData.Models;

namespace TrimlightData;
internal static class ExtensionMethods
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

    public static string HMACSHA256Hash(this string accessString, string key)
    {
        var keyBytes = Encoding.UTF8.GetBytes(key);
        var accessBytes = Encoding.UTF8.GetBytes(accessString);
        var encryptedBytes = new HMACSHA256(keyBytes).ComputeHash(accessBytes);

        return Convert.ToBase64String(accessBytes);
    }
}
