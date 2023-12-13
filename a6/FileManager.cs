/* 
Lukas Jönsson
16/10-2023
*/

using System.Text.Json;
namespace Solution_Assignment_6;


/// <summary>
/// FileManager class
/// </summary>
public class FileManager
{
    /// <summary>
    /// FileManager constructor
    /// </summary>
    public FileManager()
    {

    }

    /// <summary>
    /// Method that return a MemoryStream with the serialized task list
    /// Implemented JSON, therefore each attribute of the task are represented
    /// by a key-value pair which facilitates the structure of the data. In the
    /// 'ReadAndDeserializeTaskList' the keys and values are used when creating
    /// the task object
    /// https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/how-to?pivots=dotnet-8-0
    /// </summary>
    /// <param name="taskList">The task list</param>
    /// <returns>MemoryStream with the serialized task list</returns>
    public MemoryStream SerializeTaskList(List<Task> taskList)
    {
        // The list where each serialized task will be stored
        List<string> serializedTasks = new List<string>();

        for (int i = 0; i < taskList.Count; i++)
        {
            Task task = new Task()
            {
                Date = taskList[i].Date,
                Time = taskList[i].Time,
                Priority = taskList[i].Priority,
                Text = taskList[i].Text
            };
            string serializedTask = JsonSerializer.Serialize(task);
            serializedTasks.Add(serializedTask);
        }
        // Serialize the list 'serializedTasks'
        byte[] serializedTaskList = JsonSerializer.SerializeToUtf8Bytes(serializedTasks);
        return new MemoryStream(serializedTaskList);
    }

    /// <summary>
    /// Method that return if the stream with the serialized task list was read
    /// and each deserialized task was added to the task list
    /// </summary>
    /// <param name="taskList">The task list</param>
    /// <param name="taskListStream">Stream with the serialized task list</param>
    /// <returns>True if the task list is read and deserialized, otherwise false</returns>
    public bool ReadAndDeserializeTaskList(List<Task> taskList, Stream taskListStream)
    {
        bool isRead = false;

        try
        {
            // If there are tasks in the 'taskList' then clear it
            if (taskList != null)
            {
                taskList.Clear();
            }
            else
            {
                taskList = new List<Task>();
            }
            // Read the serialized task list stream
            string serializedTaskList = new StreamReader(taskListStream).ReadToEnd();
            List<string> deserializedTaskList = JsonSerializer.Deserialize<List<string>>(serializedTaskList);

            if (deserializedTaskList.Count > 0)
            {
                for (int i = 0; i < deserializedTaskList.Count; i++)
                {
                    // Deserialize each task object and add to the 'taskList'
                    Task task = JsonSerializer.Deserialize<Task>(deserializedTaskList[i]);
                    taskList.Add(task);
                }
                isRead = true;
            }
        }
        /*
        try-catch based on the following source
        https://www.w3schools.com/cs/cs_exceptions.php
        */
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return isRead;
    }
}