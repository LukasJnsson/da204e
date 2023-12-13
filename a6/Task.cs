/* 
Lukas Jönsson
16/10-2023
*/

namespace Solution_Assignment_6;


/// <summary>
/// Task class
/// </summary>
public class Task
{
    /// <summary>
    /// The private attributes
    /// </summary>
    private DateTime date;
    private TimeSpan time;
    private TaskPriorityType priority;
    private string text;


    /// <summary>
    /// Task constructor
    /// </summary>
    public Task()
    {
        priority = TaskPriorityType.Normal;
    }

    /// <summary>
    /// Property that Get and Set the attribute 'date'
    /// </summary>
    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }

    /// <summary>
    /// Property that Get and Set the attribute 'time'
    /// </summary>
    public TimeSpan Time
    {
        get { return time; }
        set { time = value; }
    }

    /// <summary>
    /// Property that Get and Set the attribute 'priority'
    /// </summary>
    public TaskPriorityType Priority
    {
        get { return priority; }
        set { priority = value; }
    }

    /// <summary>
    /// Property that Get and Set the attribute 'text'
    /// </summary>
    public string Text
    {
        get { return text; }
        set
        {
            if (Util.ValidateString(value))
            {
                text = value;
            }
        }
    }

    /// <summary>
    /// Method that return the task DateTime date string
    /// </summary>
    /// <returns>The date string</returns>
    private string GetDateTimeDate()
    {
        return $"{Date.Year}-{Date.Month}-{Date.Day}";
    }

    /// <summary>
    /// Method that return the task TimeSpan time string
    /// </summary>
    /// <returns>The time string</returns>
    private string GetDateTimeTime()
    {
        return $"{Time.Hours.ToString("00")}:{Time.Minutes.ToString("00")}";
    }

    /// <summary>
    /// Method that override the default 'ToString' by implementing the specified format
    /// for each task
    /// </summary>
    /// <returns>The task string</returns>
    public override string ToString()
    {
        return $"{GetDateTimeDate()} {GetDateTimeTime()} {text} ({Util.GetEnumString(priority)})";
    }
}