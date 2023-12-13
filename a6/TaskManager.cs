/* 
Lukas Jönsson
16/10-2023
*/

namespace Solution_Assignment_6;


/// <summary>
/// TaskManager class
/// </summary>
public class TaskManager
{
    /// <summary>
    /// The private attribute equal the task list
    /// </summary>
    private List<Task> taskList;


    /// <summary>
    /// TaskManager constructor
    /// </summary>
    public TaskManager()
    {
        // Init the task list
        taskList = new List<Task>();
    }

    /// <summary>
    /// Method that add task
    /// </summary>
    /// <param name="task">The task object</param>
    /// <returns>True if task added, otherwise false</returns>
    public bool AddTask(Task task)
    {
        bool isAdded = false;

        if (task != null)
        {
            taskList.Add(task);
            isAdded = true;
        }
        return isAdded;
    }

    /// <summary>
    /// Method that return the tasks in the task list
    /// </summary>
    /// <returns>An array with the tasks in the task list</returns>
    public string[] GetTasks()
    {
        string[] tasks = new string[taskList.Count];
        int index = 0;

        foreach (Task task in taskList)
        {
            tasks[index++] = task.ToString();
        }
        return tasks;
    }

    /// <summary>
    /// Method that return the number of tasks in the task list that are due today
    /// </summary>
    /// <returns>Integer with the number of tasks that are due today</returns>
    public int GetNumberOfTasksToday()
    {
        int tasksToday = 0;

        foreach (Task task in taskList)
        {
            if (task.Date == Util.GetDate())
            {
                tasksToday++;
            }
        }
        return tasksToday;
    }

    /// <summary>
    /// Method that return MemoryStream with the serialized task list
    /// </summary>
    /// <returns>MemoryStream with the serialized task list</returns>
    public MemoryStream SaveTaskDataToFile()
    {
        FileManager fileManager = new FileManager();
        return fileManager.SerializeTaskList(taskList);
    }

    /// <summary>
    /// Method that return if the .json file was read and deserialized
    /// </summary>
    /// <param name="taskListStream">Stream with the serialized task list</param>
    /// <returns>True if the .json file was read and deserialized, otherwise false</returns>
    public bool ReadTaskDataFromFile(Stream taskListStream)
    {
        FileManager fileManager = new FileManager();
        return fileManager.ReadAndDeserializeTaskList(taskList, taskListStream);
    }
}