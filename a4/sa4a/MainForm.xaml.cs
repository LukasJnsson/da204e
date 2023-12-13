/* 
Lukas Jönsson
21/9-2023
*/

namespace Solution_Assignment_4_PartyOrganizer;


/*
MainForm class
*/
public partial class MainForm : ContentPage
{
    // Create new 'PartyManager' object
    PartyManager partyManager;


    /*
	Method that execute the initialization methods when the 'ContentPage' renders
	*/
    public MainForm()
	{
		InitializeComponent();
        InitializeInitialInterface();
    }

    /*
	Method that initialize the input controls to the initial state
	*/
    private void InitializeInputControls()
	{
		maxNumEntry.Text = string.Empty;
		costEntry.Text = string.Empty;
		feeEntry.Text = string.Empty;

        firstNameEntry.Text = string.Empty;
        firstNameEntry.IsEnabled = false;
        lastNameEntry.Text = string.Empty;
		lastNameEntry.IsEnabled = false;
    }

    /*
	Method that initialize the output controls to the initial state
	*/
    private void InitializeOutputControls()
    {
		newPartyLabel.Text = "New Party";
        maxNumLabel.Text = "Number Of Guests";
		costLabel.Text = "Cost per Guest";
		feeLabel.Text = "Fee per Guest";
        createPartyBtn.Text = "Create Party";

		inviteGuestLabel.Text = "Invite Guest";
        firstNameLabel.Text = "First name";
        lastNameLabel.Text = "Last name";
		addGuestBtn.Text = "Add Guest";
        inviteGuestLabel.IsEnabled = false;
        firstNameLabel.IsEnabled = false;
        lastNameLabel.IsEnabled = false;
        addGuestBtn.IsEnabled = false;

        numOfGuestLabel.Text = "Number Of Guests";
		totalCostLabel.Text = "Total Cost";
		totalFeesLabel.Text = "Total fees";
		surplusDeficitLabel.Text = "Surplus/Deficit";
        numOfGuestFrameLabel.Text = "0";
        totalCostFrameLabel.Text = "0.00";
        totalFeesFrameLabel.Text = "0.00";
        surplusDeficitFrameLabel.Text = "0.00";

        guestListLabel.Text = "Guest List";

        deleteGuestBtn.Text = "Delete Guest";
    }

    /*
	Method that initialize the graphical user interface to the initial state
    */
    private void InitializeInitialInterface()
    {
        InitializeInputControls();
        InitializeOutputControls();
    }

    /*
	Method that update the input controls when the party is created
	*/
    private void UpdateInputControlsOnPartyCreated()
    {
        /* 
        Could not find any element equal the 'GroupBox' therefore this non
        effective manual approach
        */
        firstNameEntry.IsEnabled = true;
        lastNameEntry.IsEnabled = true;
    }

    /*
	Method that update the output controls when the party is created
	*/
    private void UpdateOutputControlsOnPartyCreated()
    {
        inviteGuestLabel.IsEnabled = true;
        firstNameLabel.IsEnabled = true;
        lastNameLabel.IsEnabled = true;
        addGuestBtn.IsEnabled = true;
    }

    /*
	Method that update the output controls for the guest list calculations
	*/
    private void UpdateGuestListCalculationsOutputControls()
    {
        numOfGuestFrameLabel.Text = partyManager.GetGuestList().Length.ToString();
        totalCostFrameLabel.Text = partyManager.GetTotalCost().ToString("0.00");
        totalFeesFrameLabel.Text = partyManager.GetTotalFees().ToString("0.00");
        surplusDeficitFrameLabel.Text = partyManager.GetSurplusDeficit().ToString("0.00");
    }

    /*
    Method that update the input controls after add guest
    */
    private void UpdateInputControlsAfterAddGuest()
    {
        firstNameEntry.Text = string.Empty;
        lastNameEntry.Text = string.Empty;
    }

    /*
    Method that initialize the guest list
    */
    private void InitializeGuestList()
    {
        string[] guestList = partyManager.GetGuestList();

        // Create new array with the formatted guests
        string[] formattedGuestList = new string[guestList.Length];

        if (guestList != null)
        {
            // Iterate through the 'guestList' and add the formatted guest to the new array
            for (int index = 0; index < guestList.Length; index++)
            {
                formattedGuestList[index] = $"{index + 1}. {guestList[index]}";
            }
            // Set the 'formattedGuestList' to the 'ItemsSource'
            guestListView.ItemsSource = formattedGuestList;
        }
    }

    /*
	Method that display validation message by using the implemented method 'DisplayAlert'
	*/
    private void DisplayValidationMessage(string title, string text)
	{
		DisplayAlert(title, text, "Continue");
	}

    /*
	Method that validates if Entry is null or empty
	*/
    private bool ValidateEntry(Entry entryName)
    {
        return !string.IsNullOrEmpty(entryName.Text.Trim());
    }

    /*
	Method that validates if the data type of the Entry text is double
	*/
    private bool ValidateEntryDouble(Entry text)
	{
		double validDataType;
		return double.TryParse(text.Text, out validDataType);
	}

    /*
	Method that validates if the data type of the Entry text is int
	*/
    private bool ValidateEntryInt(Entry text)
    {
        int validDataType;
        return int.TryParse(text.Text, out validDataType);
    }

    /*
    Method that trim and return Entry with the data type string
    */
    private string TrimEntryString(Entry text)
    {
        return text.Text.Trim();
    }

    /*
    Method that trim and return Entry with the data type double
    */
    private double TrimEntryDouble(Entry text)
    {
        return double.Parse(text.Text.Trim());
    }

    /*
	Method that trim and return Entry with the data type int
	*/
    private int TrimEntryInt(Entry text)
	{
		return int.Parse(text.Text.Trim());
	}

    /*
	Method that validate the 'Number Of Guests' Entry
	*/
    private bool ValidateNumberOfGuests()
    {
        bool isValid = false;

        if (ValidateEntry(maxNumEntry) && ValidateEntryInt(maxNumEntry) && (TrimEntryInt(maxNumEntry) > 0))
        {
            isValid = true;
        }
        else
        {
            DisplayValidationMessage("Error", "Please enter the maximum number of guests!");
        }
        return isValid;
    }

    /*
	Method that return the number of guests
	*/
    private int GetNumberOfGuests()
	{
		return TrimEntryInt(maxNumEntry);
    }

    /*
	Method that validate the 'Cost Per Guest' Entry
	*/
    private bool ValidateCostPerGuest()
    {
        bool isValid = false;

        if (ValidateEntry(costEntry) && ValidateEntryDouble(costEntry) && (TrimEntryDouble(costEntry) > 0))
        {
            isValid = true;
        }
        else
        {
            DisplayValidationMessage("Error", "Please enter the cost per guest!");
        }
        return isValid;
    }

    /*
	Method that set the 'costPerGuest' attribute
	*/
    private void SetCostPerGuest()
	{
        partyManager.CostPerGuest = TrimEntryDouble(costEntry);
    }

    /*
	Method that validate the 'Fee Per Guest' Entry
	*/
    private bool ValidateFeePerGuest()
    {
        bool isValid = false;

        if (ValidateEntry(feeEntry) && ValidateEntryDouble(feeEntry) && (TrimEntryDouble(feeEntry) > 0))
        {
            isValid = true;
        }
        else
        {
            DisplayValidationMessage("Error", "Please enter the fee per guest!");
        }
        return isValid;
    }

    /*
	Method that set the 'feePerGuest' attribute
	*/
    private void SetFeePerGuest()
	{
        partyManager.FeePerGuest = TrimEntryDouble(feeEntry);
    }

    /*
    Method that validate the 'First Name' and 'Last Name' Entry
    */
    private bool ValidateName(Entry text, string name)
    {
        bool isValid = false;

        if (ValidateEntry(text))
        {
            isValid = true;
        }
        else
        {
            DisplayValidationMessage("Error", $"Please enter {name} name!");
        }
        return isValid;
    }

    /*
	Method that add guest
	*/
    private void AddGuest()
    {
        if (ValidateName(firstNameEntry, "first") && ValidateName(lastNameEntry, "last"))
        {
            partyManager.AddGuest(TrimEntryString(firstNameEntry), TrimEntryString(lastNameEntry));
        }
    }

    /*
    Method that execute the 'AddGuest' method and methods that update the interface
    */
    private void ButtonClickedAddGuest(object sender, EventArgs e)
    {
        // If the number of guests equals the set maximum number then the party is full
        if (partyManager.GetGuestList().Length == partyManager.MaxNumberOfGuests)
        {
            DisplayValidationMessage("Error", "Please notice that the guest list is full!");
        }
        else
        {
            AddGuest();
            UpdateInputControlsAfterAddGuest();
            UpdateGuestListCalculationsOutputControls();
            InitializeGuestList();
        }
    }

    /*
    Method that delete guest
    */
    private void DeleteGuest(int index)
    {
        if (partyManager.DeleteGuest(index))
        {
            DisplayValidationMessage("Success", "Successfully deleted guest!");
        }
        else
        {
            DisplayValidationMessage("Error", "Could not delete guest!");
        }
    }

    /*
    Method that return the index of the selected guest in the 'ListView'
    */
    private int GetSelectedGuestIndex()
    {
        /*
        'Substring(0, guest.IndexOf(".")' returns the string from the first character to
        the "." character. This approach extracts the displayed index of the guest. Since
        '+1' is added when formatting the guests in the 'InitializeGuestList' method '-1'
        needs to be implemented to get the actual index of the guest in the 'guestList'
        https://learn.microsoft.com/en-us/dotnet/api/system.string.substring?view=net-7.0
        'guest.IndexOf(".")' returns the index of the "."
        https://learn.microsoft.com/en-us/dotnet/api/system.string.indexof?view=net-7.0
        */
        string guest = guestListView.SelectedItem.ToString();
        int guestIndex = int.Parse(guest.Substring(0, guest.IndexOf("."))) - 1;
        return guestIndex;
    }

    /*
    Method that execute the 'DeleteGuest' method and methods that update the interface
    */
    private void ButtonClickedDeleteGuest(object sender, EventArgs e)
    {
        if (partyManager.GetGuestList().Length == 0)
        {
            /*
            Another approach could be to hide the "Delete Guest" button before
            the first guest has been added
            */
            DisplayValidationMessage("Error", "Please add guest before deleting it!");
        }
        else
        {
            DeleteGuest(GetSelectedGuestIndex());
            UpdateGuestListCalculationsOutputControls();
            InitializeGuestList();
        }
    }

    /*
	Method that create party
	*/
    private bool CreateParty()
    {
        bool isCreated = false;

        // Validate each entry
        if (ValidateNumberOfGuests() && ValidateCostPerGuest() && ValidateFeePerGuest())
        {
            /*
            Create new instance of the 'PartyManager' class, set the attributes and
            the size of the guests array
            */
            partyManager = new PartyManager(GetNumberOfGuests());
            SetCostPerGuest();
            SetFeePerGuest();

            DisplayValidationMessage("Success", $"Party created with {partyManager.MaxNumberOfGuests} guests!");

            isCreated = true;
        }
        return isCreated;
    }

    /*
	Method that execute the 'CreateParty' method and methods that update the interface
	*/
    private void ButtonClickedCreateParty(object sender, EventArgs e)
	{
        if (CreateParty())
        {
            UpdateOutputControlsOnPartyCreated();
            UpdateInputControlsOnPartyCreated();
            UpdateGuestListCalculationsOutputControls();
            InitializeGuestList();
        }
        else
        {
            // Initialize the initial interface on validation error
            InitializeInitialInterface();
        }
    }
}