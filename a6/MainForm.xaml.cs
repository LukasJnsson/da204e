/* 
Lukas Jönsson
16/10-2023
The 'FileSaver' require the 'MAUI Community Toolkit' therefore this was installed
as dependency. Install the dependencies by right click on the solution and execute
the command 'Restore NuGet Packages'
*/

using CommunityToolkit.Maui.Storage;
namespace Solution_Assignment_6;


/// <summary>
/// MainForm class
/// </summary>
public partial class MainForm : ContentPage
{
    /// <summary>
    /// The private attribute
    /// </summary>   
    private TaskManager taskManager;


    /// <summary>
    /// MainForm constructor that execute the initialization methods when
    /// the 'ContentPage' renders
    /// </summary>
    public MainForm()
    {
        InitializeComponent();
        InitializeInitialInterface();
    }

    /// <summary>
    /// Method that initialize the input controls to the initial appearance
    /// </summary>
    private void InitializeInputControls()
    {
        todoDatePicker.Date = Util.GetDate();
        todoTimePicker.Time = Util.GetTime();
        todoPriorityPicker.ItemsSource = Enum.GetNames(typeof(TaskPriorityType));
        todoPriorityPicker.SelectedIndex = (int)TaskPriorityType.Normal;
        todoTextEntry.Text = string.Empty;
    }

    /// <summary>
    /// Method that initialize the output controls to the initial appearance
    /// </summary>
    private void InitializeOutputControls()
    {
        menuBarItemFile.Text = "File";
        menuBarItemNew.Text = "New";
        menuBarItemOpen.Text = "Open data file";
        menuBarItemSave.Text = "Save data file";
        menuBarItemExit.Text = "Exit";

        menuBarItemHelp.Text = "Help";
        menuBarItemAbout.Text = "About";

        todoDateTimeLabel.Text = "Date And Time";
        todoPriorityLabel.Text = "Priority";
        todoTextLabel.Text = "New ToDo";
        todoAddBtn.Text = "Add ToDo";
        toDoListView.ItemsSource = null;

        todoListViewLabel.Text = "ToDo";
        todosTodayLabel.Text = InitializeTodosTodayString();
    }

    /// <summary>
    /// Method that initialize the initial interface
    /// </summary>
    private void InitializeInitialInterface()
    {
        taskManager = new TaskManager();
        InitializeInputControls();
        InitializeOutputControls();
    }

    /// <summary>
    /// Method that initialize the interface when the task list is updated
    /// </summary>
    private void InitializeUpdatedInterface()
    {
        toDoListView.ItemsSource = taskManager.GetTasks();
        todosTodayLabel.Text = InitializeTodosTodayString();
        InitializeInputControls();
    }

    /// <summary>
    /// Method that return string with the number of tasks that are due today
    /// </summary>
    private string InitializeTodosTodayString()
    {
        int numberOfTasks = taskManager.GetTasks().Length;
        int numberOfTasksToday = taskManager.GetNumberOfTasksToday();
        string todosTodayString = "There are no ToDos due today...";

        if (numberOfTasksToday > 0)
        {
            todosTodayString = $"{numberOfTasksToday}/{numberOfTasks} ToDos are due today!";
        }
        return todosTodayString;
    }

    /// <summary>
    /// Method the display validation information with the native 'DisplayAlert'
    /// method
    /// </summary>
    /// <param name="title">The validation title</param>
    /// <param name="information">The validation information</param>
    private void DisplayValidation(string title, string information)
    {
        DisplayAlert(title, information, "Continue");
    }

    /// <summary>
    /// Method that return new task based on the values in the input controls
    /// </summary>
    /// <returns>The created task if the text entry is valid, otherwise null</returns>
    private Task CreateTask()
    {
        Task task = null;

        if (Util.ValidateString(todoTextEntry.Text))
        {
            task = new Task();
            task.Date = todoDatePicker.Date;
            task.Time = todoTimePicker.Time;
            task.Priority = (TaskPriorityType)todoPriorityPicker.SelectedIndex;
            task.Text = todoTextEntry.Text.Trim();
        }
        return task;
    }

    /// <summary>
    /// Event handler method that add new task
    /// </summary>
    /// <param name="sender">The object that invoked the event</param>
    /// <param name="e">The event data</param>
    private void HandleAdd(object sender, EventArgs e)
    {
        if (taskManager.AddTask(CreateTask()))
        {
            InitializeUpdatedInterface();
        }
        else
        {
            DisplayValidation("Error", $"Please enter text!");
        }
    }

    /// <summary>
    /// Event handler method that re-initialize the application
    /// </summary>
    /// <param name="sender">The object that invoked the event</param>
    /// <param name="e">The event data</param>
    private void HandleNewFile(object sender, EventArgs e)
    {
        InitializeInitialInterface();
    }

    /// <summary>
    /// Event handler method that save the task list with the native 'FileSaver'
    /// Implemented the 'FileSaver' based on the following source
    /// https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/essentials/file-saver?tabs=windows
    /// </summary>
    /// <param name="sender">The object that invoked the event</param>
    /// <param name="e">The event data</param>
    private async void HandleSaveFile(object sender, EventArgs e)
    {
        MemoryStream tasksList = taskManager.SaveTaskDataToFile();
        var fileSaverResponse = await FileSaver.SaveAsync("tasks.json", tasksList, default);

        if (fileSaverResponse.IsSuccessful)
        {
            DisplayValidation("Success", $"Task list saved to {fileSaverResponse.FilePath}");
        }
        else
        {
            DisplayValidation("Error", $"Could not save file...");
        }
    }

    /// <summary>
    /// Event handler method that open the task list with the native 'FilePicker'
    /// Implemented the 'FilePicker' based on the following source
    /// https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/storage/file-picker?tabs=windows
    /// </summary>
    /// <param name="sender">The object that invoked the event</param>
    /// <param name="e">The event data</param>
    private async void HandleOpenFile(object sender, EventArgs e)
    {
        var fileOpenerResponse = await FilePicker.PickAsync();
        Stream stream = await fileOpenerResponse.OpenReadAsync();

        if (fileOpenerResponse != null)
        {
            if (taskManager.ReadTaskDataFromFile(stream))
            {
                InitializeUpdatedInterface();
            }
            else
            {
                DisplayValidation("Error", $"Could not find any tasks in the task list...");
            }
        }
        else
        {
            DisplayValidation("Error", $"Could not open file...");
        }
    }

    /// <summary>
    /// Event handler method that exit the application
    /// Implemented the 'DisplayAlert' based on the following soruce
    /// https://learn.microsoft.com/en-us/dotnet/maui/user-interface/pop-ups
    /// </summary>
    /// <param name="sender">The object that invoked the event</param>
    /// <param name="e">The event data</param>
    private async void HandleExitApp(object sender, EventArgs e)
    {
        bool continueResponse = await DisplayAlert("Exit ToDo Reminder", "Are you sure you want to exit the ToDo Reminder?", "Cancel", "Exit");
        if (!continueResponse)
        {
            Application.Current.Quit();
        }
    }
}