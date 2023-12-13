/* 
Lukas Jönsson
16/10-2023
*/

namespace Solution_Assignment_6;


/// <summary>
/// Util class
/// Implemented this static class with reusable methods
/// </summary>
public static class Util
{
    /// <summary>
    /// Method that return the enum variable in string format without underlines
    /// </summary>
    /// <param name="enum">The enum</param>
    /// <returns>The enum string without underlines</returns>
    public static string GetEnumString(Enum @enum)
    {
        return @enum.ToString().Replace("_", " ");
    }

    /// <summary>
    /// Method that validate that string is not null or empty
    /// </summary>
    /// <param name="value">The string to validate</param>
    /// <returns>True if the string is not null or empty, otherwise false</returns>
    public static bool ValidateString(string value)
    {
        return !string.IsNullOrEmpty(value.Trim());
    }

    /// <summary>
    /// Method that return the current DateTime date
    /// </summary>
    /// <returns>The current date</returns>
    public static DateTime GetDate()
    {
        return DateTime.Now.Date;
    }

    /// <summary>
    /// Method that return the current TimeSpan time
    /// </summary>
    /// <returns>The current time</returns>
    public static TimeSpan GetTime()
    {
        return new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0);
    }
}