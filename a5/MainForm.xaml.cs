/* 
Lukas Jönsson
3/10-2023
XML documentation format based on the following source
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/
*/

namespace Solution_Assignment_5;


/// <summary>
/// MainForm class
/// </summary>
public partial class MainForm : ContentPage
{
    /// <summary>
    /// The private attribute equal an object of the EventManager class
    /// </summary>
    private EventManager eventManager;


    /// <summary>
    /// MainForm constructor that execute the initialization methods when the
    /// 'ContentPage' renders
    /// </summary>
    public MainForm()
    {
        InitializeComponent();
        InitializeInitialInterface();
    }

    /// <summary>
    /// Method that initialize the input controls to the initial state
    /// </summary>
    private void InitializeInputControls()
    {
        eventTitleEntry.Text = string.Empty;
        eventCostEntry.Text = string.Empty;
        eventFeeEntry.Text = string.Empty;

        firstNameEntry.IsEnabled = false;
        lastNameEntry.IsEnabled = false;
        streetEntry.IsEnabled = false;
        cityEntry.IsEnabled = false;
        zipCodeEntry.IsEnabled = false;
        countryPicker.IsEnabled = false;
        addParticipantBtn.IsEnabled = false;
        changeParticipantBtn.IsEnabled = false;
        deleteParticipantBtn.IsEnabled = false;
    }

    /// <summary>
    /// Method that initialize the output controls to the initial state
    /// </summary>
    private void InitializeOutputControls()
    {
        this.Title = "Event Organizer by Lukas Jönsson with .NET MAUI";
        newEventLabel.Text = "New Event";
        eventTitleLabel.Text = "Event Title";
        eventCostLabel.Text = "Cost per Participant";
        eventFeeLabel.Text = "Fee per Participant";
        createEventBtn.Text = "Create Event";

        addParticipantLabel.Text = "Add Participant";
        firstNameLabel.Text = "First Name";
        lastNameLabel.Text = "Last Name";
        streetLabel.Text = "Street";
        cityLabel.Text = "City";
        zipCodeLabel.Text = "Zip Code";
        countryLabel.Text = "Country";
        addParticipantBtn.Text = "Add Participant";

        participantListViewLabel.Text = "Participants";
        changeParticipantBtn.Text = "Change Participant";
        deleteParticipantBtn.Text = "Delete Participant";

        eventEconomyLabel.Text = "Event Economy";
        numberOfParticipantsLabel.Text = "Number Of Participants";
        totalCostLabel.Text = "Total Cost";
        totalFeeLabel.Text = "Total fees";
        surplusDeficitLabel.Text = "Surplus/Deficit";
        numberOfParticipantsFrameLabel.Text = "0";
        totalCostFrameLabel.Text = "0.00";
        totalFeeFrameLabel.Text = "0.00";
        surplusDeficitFrameLabel.Text = "0.00";
    }

    /// <summary>
    /// Method that initialize the interface to the initial state
    /// </summary>
    private void InitializeInitialInterface()
    {
        InitializeInputControls();
        InitializeOutputControls();
    }

    /// <summary>
    /// Method that initialize the participant and participants input controls
    /// </summary>
    private void InitializeParticipantAndParticipantsInputControls()
    {
        // Enable each entry and set equal to empty string
        firstNameEntry.IsEnabled = true; firstNameEntry.Text = string.Empty;
        lastNameEntry.IsEnabled = true; lastNameEntry.Text = string.Empty;
        streetEntry.IsEnabled = true; streetEntry.Text = string.Empty;
        cityEntry.IsEnabled = true; cityEntry.Text = string.Empty;
        zipCodeEntry.IsEnabled = true; zipCodeEntry.Text = string.Empty;
        /*
        Set the 'ItemsSource' of the picker equal the countries
        Set the initial 'SelectedIndex' equal 'United_States_of_America'
        https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/picker
        */
        countryPicker.IsEnabled = true;
        countryPicker.ItemsSource = Enum.GetNames(typeof(Countries));
        countryPicker.SelectedIndex = (int)Countries.United_States_of_America;
        addParticipantBtn.IsEnabled = true;

        changeParticipantBtn.IsEnabled = true;
        deleteParticipantBtn.IsEnabled = true;
    }

    /// <summary>
    /// Method that initialize the participant and participants output controls
    /// </summary>
    private void InitializeParticipantAndParticipantsOutputControls()
    {
        participantListView.ItemsSource = eventManager.Participants.GetParticipants();
        numberOfParticipantsFrameLabel.Text = eventManager.Participants.GetNumberOfParticipants.ToString();
        totalCostFrameLabel.Text = eventManager.CalculateTotalCost().ToString("0.00");
        totalFeeFrameLabel.Text = eventManager.CalculateTotalFee().ToString("0.00");
        surplusDeficitFrameLabel.Text = eventManager.CalculateSurplusDeficit().ToString("0.00");
    }

    /// <summary>
    /// Method that initialize the participant by setting its properties in
    /// the entries
    /// </summary>
    /// <param name="participant">The participant object</param>
    private void InitializeParticipant(Participant participant)
    {
        firstNameEntry.Text = participant.FirstName;
        lastNameEntry.Text = participant.LastName;
        streetEntry.Text = participant.Address.Street;
        cityEntry.Text = participant.Address.City;
        zipCodeEntry.Text = participant.Address.ZipCode;
        countryPicker.SelectedIndex = (int)participant.Address.Country;
    }

    /// <summary>
    /// Method that display custom validation message by using the native
    /// 'DisplayAlert' method
    /// </summary>
    /// <param name="title">The title of the message</param>
    /// <param name="information">The information in the message</param>
    private void DisplayValidationMessage(string title, string information)
    {
        DisplayAlert(title, information, "Continue");
    }

    /// <summary>
    /// Method that validate entry string text
    /// </summary>
    /// <param name="entry">The entry to validate</param>
    /// <returns>True if not null or empty, otherwise false</returns>
    private bool ValidateEntryString(Entry entry)
    {
        return !string.IsNullOrEmpty(entry.Text.Trim());
    }

    /// <summary>
    /// Method that validate entry double text
    /// </summary>
    /// <param name="entry">The entry to validate</param>
    /// <returns>True if entry text equals the data type double, otherwise false</returns>
    private bool ValidateEntryDouble(Entry entry)
    {
        double validDataType;
        return double.TryParse(entry.Text.Trim(), out validDataType);
    }

    /// <summary>
    /// Method that return the trimmed entry text string
    /// </summary>
    /// <param name="entry">The entry to trim</param>
    /// <returns>The trimmed entry text string</returns>
    private string TrimmedEntryString(Entry entry)
    {
        return entry.Text.Trim();
    }

    /// <summary>
    /// Method that return the parsed and trimmed entry text double
    /// </summary>
    /// <param name="entry">The entry to parse and trim</param>
    /// <returns>The trimmed entry text double</returns>
    private double TrimmedEntryDouble(Entry entry)
    {
        return double.Parse(entry.Text.Trim());
    }

    /// <summary>
    /// Method that validate the event entries
    /// </summary>
    /// <returns>True if all entries are valid, otherwise false</returns>
    private bool ValidateEvent()
    {
        bool isValid = true;

        Dictionary<Entry, string> entriesToValidate = new Dictionary<Entry, string>
        {
            {eventTitleEntry, "event title" },
            {eventCostEntry, "cost per participant" },
            {eventFeeEntry, "fee per participant" }
        };

        foreach (KeyValuePair<Entry, string> entry in entriesToValidate)
        {
            /*
            Since the there are entries with different data types, if the entry.Key
            equals 'eventTitleEntry' then use the 'ValidateEntryString' instead of
            the 'ValidateEntryDouble'
            */
            if (entry.Key == eventTitleEntry)
            {
                if (!ValidateEntryString(entry.Key))
                {
                    DisplayValidationMessage("Error", $"Please enter {entry.Value}!");
                    isValid = false;
                }
            }
            else
            {
                if (!ValidateEntryDouble(entry.Key))
                {
                    DisplayValidationMessage("Error", $"Please enter {entry.Value}!");
                    isValid = false;
                }
            }
        }
        return isValid;
    }

    /// <summary>
    /// Method that set the EventManager attributes
    /// </summary>
    private void SetEvent()
    {
        eventManager.Title = TrimmedEntryString(eventTitleEntry);
        eventManager.CostPerParticipant = TrimmedEntryDouble(eventCostEntry);
        eventManager.FeePerParticipant = TrimmedEntryDouble(eventFeeEntry);

        // Set title the title in the desktop window
        this.Title = $"{eventManager.Title} By Lukas Jönsson";
    }

    /// <summary>
    /// Method that validate the participant entries and the country picker
    /// </summary>
    /// <returns>True if all entries and the picker are valid, otherwise false</returns>
    private bool ValidateParticipant()
    {
        /*
        Implemented another approach that is more efficient by creating a dictionary
        with key-value pairs, each key represents an entry while each value equals the
        the specific validation information for example 'first name', 'last name' etc.
        The dictionary will be iterated through validating each entry and setting the
        specific error information. Since most of the code for each entry are the same
        this approach will reduce the amount of code. In terms of scalability it will
        be easier to add new entries without the need to adding new Get and Set methods
        Based on the following sources
        https://www.geeksforgeeks.org/c-sharp-dictionary-with-examples/
        https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-7.0

        The following approach would result in repetitive code
        bool isValid = true;
        if (!ValidateEntryString(firstNameEntry))
        {
            DisplayValidationMessage("Error", "Please enter first name!");
            isValid = false;
        }

        if (!ValidateEntryString(lastNameEntry))
        {
            DisplayValidationMessage("Error", "Please enter last name!");
            isValid = false;
        }
        return isValid;
        */

        bool isValid = true;

        Dictionary<Entry, string> entriesToValidate = new Dictionary<Entry, string>
        {
            {firstNameEntry, "first name" },
            {lastNameEntry, "last name" },
            {streetEntry, "street" },
            {cityEntry, "city" },
            {zipCodeEntry, "zip code" },
        };

        foreach (KeyValuePair<Entry, string> entry in entriesToValidate)
        {
            if (!ValidateEntryString(entry.Key))
            {
                DisplayValidationMessage("Error", $"Please enter {entry.Value}!");
                isValid = false;
            }
        }
        /*
        The default value '-1' equals no country selected
        https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/picker
        */
        if (countryPicker.SelectedIndex == -1)
        {
            DisplayValidationMessage("Error", $"Please enter contry!");
            isValid = false;
        }
        return isValid;
    }

    /// <summary>
    /// Method that create and return an instance of the Participant class
    /// </summary>
    /// <returns>The created participant</returns>
    private Participant GetParticipant()
    {
        Participant participant = new Participant();
        participant.Address.City = TrimmedEntryString(cityEntry);
        participant.Address.Country = (Countries)countryPicker.SelectedIndex;
        participant.Address.Street = TrimmedEntryString(streetEntry);
        participant.Address.ZipCode = TrimmedEntryString(zipCodeEntry);
        participant.FirstName = TrimmedEntryString(firstNameEntry);
        participant.LastName = TrimmedEntryString(lastNameEntry);
        return participant;
    }

    /// <summary>
    /// Method that add participant by validateing each entry and then use the
    /// 'AddParticipant' method in ParticipantManager
    /// </summary>
    /// <returns>True if participant added, otherwise false</returns>
    private bool AddParticipant()
    {
        bool participantAdded = false;

        if (ValidateParticipant())
        {
            if (eventManager.Participants.AddParticipant(GetParticipant()))
            {
                /*
                If selecting an existing participant from the ListView to use
                their properties when adding a new participant the index need
                to be restored to the initial state (the default value 'null' equals
                no participant selected). Otherwise the selected participant will
                remain selected. Implement later...
                */
                InitializeParticipantAndParticipantsInputControls();
                InitializeParticipantAndParticipantsOutputControls();
                participantAdded = true;
            }
        }
        return participantAdded;
    }

    /// <summary>
    /// Method that execute the 'AddParticipant' method once clicked
    /// </summary>
    /// <param name="sender">The object that invoked the event</param>
    /// <param name="e">The event data</param>
    private void ButtonClickedAddParticipant(object sender, EventArgs e)
    {
        AddParticipant();
    }

    /// <summary>
    /// Method that return the index of the selected participant
    /// </summary>
    /// <returns>The index of the selected participant</returns>
    private int GetSelectedParticipantIndex()
    {
        /*
        The selected index is accessed using the 'Array.IndexOf' method since
        'SelectedIndex' does not exist in MAUI
        https://learn.microsoft.com/en-us/dotnet/api/system.array.indexof?view=net-7.0
        */
        string[] participantsCollection = eventManager.Participants.GetParticipants();
        return Array.IndexOf(participantsCollection, participantListView.SelectedItem);
    }

    /// <summary>
    /// Method that get the selected participant by using the 'GetParticipant' method
    /// in ParticipantManager and then initialize it with the 'InitializeParticipant'
    /// method
    /// </summary>
    /// <param name="index">The index of the participant in the collection</param>
    private void GetSelectedParticipant(int index)
    {
        Participant participant = new Participant();

        if (ValidateSelectedParticipant() && ValidateParticipants())
        {
            participant = eventManager.Participants.GetParticipant(index);
            InitializeParticipant(participant);
        }
    }

    /// <summary>
    /// Method that set the entries with the properties from the selected
    /// participant once clicked
    /// </summary>
    /// <param name="sender">The object that invoked the event</param>
    /// <param name="e">The event data</param>
    private void ListViewClickedSelectedParticipant(object sender, EventArgs e)
    {
        GetSelectedParticipant(GetSelectedParticipantIndex());
    }

    /// <summary>
    /// Method that validate if there is an selected participant
    /// </summary>
    /// <returns>True if there is an selected participant, otherwise false</returns>
    private bool ValidateSelectedParticipant()
    {
        bool isValid = true;

        if (GetSelectedParticipantIndex() == -1)
        {
            DisplayValidationMessage("Error", "Please select participant...");
            isValid = false;
        }
        return isValid;
    }

    /// <summary>
    /// Method that validate if there are participants in the collection
    /// </summary>
    /// <returns>True if there are participants, otherwise false</returns>
    private bool ValidateParticipants()
    {
        bool isValid = true;

        if (eventManager.Participants.GetNumberOfParticipants == 0)
        {
            DisplayValidationMessage("Error", "There are no participants...");
            isValid = false;
        }
        return isValid;
    }

    /// <summary>
    /// Method that delete participant by using the 'DeleteParticipant' method in
    /// ParticipantManager
    /// </summary>
    private void DeleteParticipant()
    {
        if (ValidateSelectedParticipant() && ValidateParticipants())
        {
            if (eventManager.Participants.DeleteParticipant(GetSelectedParticipantIndex()))
            {
                InitializeParticipantAndParticipantsInputControls();
                InitializeParticipantAndParticipantsOutputControls();
                DisplayValidationMessage("Success", "Participant deleted!");
            }
        }
    }

    /// <summary>
    /// Method that execute the 'DeleteParticipant' method once clicked
    /// </summary>
    /// <param name="sender">The object that invoked the event</param>
    /// <param name="e">The event data</param>
    private void ButtonClickedDeleteParticipant(object sender, EventArgs e)
    {
        DeleteParticipant();
    }

    /// <summary>
    /// Method that update participant by using the 'UpdateParticipant' method in
    /// ParticipantManager
    /// </summary>
    private void UpdateParticipant()
    {
        if (ValidateSelectedParticipant() && ValidateParticipant())
        {
            if (eventManager.Participants.UpdateParticipant(GetParticipant(), GetSelectedParticipantIndex()))
            {
                InitializeParticipantAndParticipantsInputControls();
                InitializeParticipantAndParticipantsOutputControls();
                DisplayValidationMessage("Success", "Participant updated!");
            }
        }
    }

    /// <summary>
    /// Method that execute the 'UpdateParticipant' method once clicked
    /// </summary>
    /// <param name="sender">The object that invoked the event</param>
    /// <param name="e">The event data</param>
    private void ButtonClickedUpdateParticipant(object sender, EventArgs e)
    {
        UpdateParticipant();
    }

    /// <summary>
    /// Method that create event
    /// </summary>
    /// <returns>True if event created, otherwise false</returns>
    private bool CreateEvent()
    {
        eventManager = new EventManager();
        bool eventCreated = false;

        if (ValidateEvent())
        {
            SetEvent();
            InitializeParticipantAndParticipantsInputControls();
            InitializeParticipantAndParticipantsOutputControls();
            DisplayValidationMessage("Success", "Event created!");
            eventCreated = true;
        }
        return eventCreated;
    }

    /// <summary>
    /// Method that execute the 'CreateEvent' method once clicked
    /// </summary>
    /// <param name="sender">The object that invoked the event</param>
    /// <param name="e">The event data</param>
    private void ButtonClickedCreateEvent(object sender, EventArgs e)
    {
        // In case the 'CreateEvent' method return false then set the initial interface
        if (!CreateEvent())
        {
            InitializeInitialInterface();
        }
    }
}