/* 
Lukas Jönsson
14/9-2023
Hi! Since I am a Mac user i used .NET MAUI to create this cross-platform application,
since the instructions where created with focus on Windows Forms i implemented the
corresponding elements, ('ContentView' equals GroupBox, 'Empty' equals 'TextBox' etc).
Each used external source is implemented in comments for example Microsofts own documentation
about the elements in XAML and MAUI, StackOverFlow for smaller syntax lookups and W3C for
implementing properties that handle Getters and Setters more efficiently compared to
separate methods for each
*/

namespace Solution_Assignment_3;


/*
MainForm class
*/
public partial class MainForm : ContentPage
{
    // Create new private instance of the 'BodyMassIndexCalculator' class
    private BodyMassIndexCalculator bmiCalculator = new BodyMassIndexCalculator();

    // Create new private instance of the 'SavingCalculator' class
    private SavingCalculator saveCalculator = new SavingCalculator();


    /*
	Method that execute the initialization methods when the 'ContentPage' renders
	*/
    public MainForm()
	{
        InitializeComponent(); // Default initialization
        // Initialize the created methods
        InitializeBodyMassIndexCalculatorInterface();
        InitializeSavingCalculatorInterface();
    }

    /*
	Method that initialize the BodyMassIndexCalculator graphical user interface
    */
    private void InitializeBodyMassIndexCalculatorInterface()
	{
		// Set the default appearance of the labels
		nameLabel.Text = "Name";
        bmiLabel.Text = "BMI";
		weightCategoryLabel.Text = "Weight Category";

        // Set the default selected radio button
        metricButton.IsChecked = true;

		// Set each Entry to empty string on render
		nameEntry.Text = string.Empty;
        majorHeightEntry.Text = string.Empty;
		weightEntry.Text = string.Empty;
    }

    /*
    Method that validate the data type of the parameter 'text'
    If the data type equals 'double' return 'true' otherwise 'false'
    */
    private bool ValidateDouble(string text)
    {
        double validDataType;
        return double.TryParse(text, out validDataType);
    }

    /*
    Method that validate the data type of the parameter 'text'
    If the data type equals 'int' return 'true' otherwise 'false'
    */
    private bool ValidateInt(string text)
    {
        int validDataType;
        return int.TryParse(text, out validDataType);
    }

    /*
    Method that display error message by using the implemented 'DisplayAlert'
    method. The implementation of the parameter 'text' enables custom error text
    */
    private void DisplayErrorMessage(string text)
    {
        DisplayAlert("Error", text, "Continue");
    }

    /*
	Method that validates the 'nameEntry' entry
	*/
    private bool GetName()
	{
		string nameEntryText = nameEntry.Text.Trim();

        // The method 'IsNullOrEmpty' returns a bool
        return !string.IsNullOrEmpty(nameEntryText);
	}

    /*
	Method that set the name attribute in the BodyMassIndexCalculator class
	*/
    private void SetName()
	{
        string nameEntryText = nameEntry.Text.Trim();

        if (GetName())
		{
			bmiCalculator.Name = nameEntryText;
        } else
		{
			bmiCalculator.Name = "Unknown";
		}
	}

    /*
	Method that validates the 'majorHeight' and/or 'minorHeight' entries
	*/
    private bool GetHeight()
	{
		bool isValid = false;
		bool majorHeight = ValidateDouble(majorHeightEntry.Text);

        // Validate if 'cm' is implemented
        if (metricButton.IsChecked)
        {
            if (majorHeight)
            {
                isValid = true;
            } else
            {
                DisplayErrorMessage("Please enter valid height in cm!");
            }
        } else
        {
            bool minorHeight = ValidateDouble(minorHeightEntry.Text);

            // Validate if 'ft' and 'in' is entered
            if (majorHeight && minorHeight)
            {
                isValid = true;
            } else
            {
                DisplayErrorMessage("Please enter valid height in ft and in!");
            }
        }
		return isValid;
    }

    /*
	Method that set the height attribute in the BodyMassIndexCalculator class
	*/
    private void SetHeight()
	{
		if (GetHeight())
		{
            /*
			Convert 'majorHeightEntry.Text' and 'minorHeightEntry.Text' string to double
			https://stackoverflow.com/questions/11399439/converting-string-to-double-in-c-sharp
			*/
            double majorHeight = double.Parse(majorHeightEntry.Text);

            if (metricButton.IsChecked)
			{
                bmiCalculator.Height = majorHeight;
            } else
			{
                double minorHeight = double.Parse(minorHeightEntry.Text) / 12;
                bmiCalculator.Height = majorHeight + minorHeight;
            }
		}
	}

    /*
	Method that validates the 'weightEntry' entry
	*/
    private bool GetWeight()
	{
        bool isValid = false;

        if (ValidateDouble(weightEntry.Text))
        {
            isValid = true;
        } else
        {
            DisplayErrorMessage("Please enter valid weight!");
        }
        return isValid;
    }

    /*
	Method that set the weight attribute in the BodyMassIndexCalculator class
	*/
    private void SetWeight()
	{
        if (GetWeight())
        {
			bmiCalculator.Weight = double.Parse(weightEntry.Text);
        }
    }

    /*
	Method that Set the metric unit to the 'heightLabel' and 'weightLabel' and
	the unit attribute in the BodyMassIndexCalculator class
	*/
    private void SetMetricChecked(object render, EventArgs e)
	{
		if (metricButton.IsChecked)
		{
            majorHeightLabel.Text = "Height (cm)";
            weightLabel.Text = "Weight (kg)";
			bmiCalculator.Unit = UnitTypes.Metric;

            // Hide 'minorHeightLabel' and 'minorHeightEntry'
            minorHeightLabel.Text = string.Empty;
            minorHeightEntry.IsVisible = false;
        }
	}

    /*
	Method that Set the imperial unit to the 'heightLabel' and 'weightLabel' and
	the unit attribute in the BodyMassIndexCalculator class
	*/
    private void SetImperialChecked(object render, EventArgs e)
    {
        if (imperialButton.IsChecked)
        {
            majorHeightLabel.Text = "Height (ft)";
            // Display 'minorHeightLabel' and 'minorHeightEntry'
            minorHeightLabel.Text = "Height (in)";
            minorHeightEntry.IsVisible = true;
			weightLabel.Text = "Weight (lb)";
            bmiCalculator.Unit = UnitTypes.Imperial;
        }
    }

    /*
	Method that validates each entry
	*/
    private bool ValidateEntries()
	{
		bool isValid = false;

        /*
        If each entry is valid then set the attributes
		The 'GetName()' is excluded since it is not required instead the
		default name will be set
        */
        if (GetHeight() && GetWeight())
		{
			SetName();
			SetHeight();
			SetWeight();
			isValid = true;
		}
		return isValid;
	}

	/*
	Method that display the BMI result
	*/
	private void DisplayBMI()
	{
        // Limit the BMI output to two decimal places
        bmiFrameLabel.Text = bmiCalculator.CalculateBodyMassIndex().ToString("f2");
        weightCategoryFrameLabel.Text = bmiCalculator.GetBMIWeightCategory();
		resultsLabel.Text = $"Results for {bmiCalculator.Name}";
		bmiInformationString.Text = bmiCalculator.GetBMIInformation();
		bmiResultString.Text = bmiCalculator.GetBMIResult();
    }

    /*
	Method that execute the method 'ValidateEntries', if the method returns true
	then continue and execute the method 'DisplayBMI'
	*/
    private void OnClickCalculateBodyMassIndexButton(object sender, EventArgs e)
    {
        if (ValidateEntries())
        {
            DisplayBMI();
        }
    }


    /*
    Method that initialize the SavingCalculator graphical user interface
    */
    private void InitializeSavingCalculatorInterface()
    {
        monthlyDepositLabel.Text = "Monthly deposit";
        periodLabel.Text = "Period (Years)";
        futureValueLabel.Text = "Future Value";
        amountPaidLabel.Text = "Amount paid";
        finalBalanceLabel.Text = "Final balance";

        monthlyDepositEntry.Text = string.Empty;
        periodEntry.Text = string.Empty;
        amountPaidFrameLabel.Text = string.Empty;
        finalBalanceFrameLabel.Text = string.Empty;
    }

    /*
    Method that Get and Set the 'monthlyDeposit' attribute in the SavingCalculator class
    */
    private bool GetAndSetMonthlyDeposit()
    {
        bool isValid = false;

        if (ValidateDouble(monthlyDepositEntry.Text))
        {
            saveCalculator.MonthlyDeposit = double.Parse(monthlyDepositEntry.Text);
            isValid = true;
        } else
        {
            DisplayErrorMessage("Please enter valid monthly deposit!");
        }
        return isValid;
    }

    /*
    Method that Get and Set the 'period' attribute in the SavingCalculator class
    */
    private bool GetAndSetPeriod()
    {
        bool isValid = false;

        if (ValidateInt(periodEntry.Text))
        {
            saveCalculator.Period = int.Parse(periodEntry.Text);
            isValid = true;
        } else
        {
            DisplayErrorMessage("Please enter valid period!");
        }
        return isValid;
    }

    /*
    Method that display the calculated result
    */
    private void DisplayFutureValue()
    {
        amountPaidFrameLabel.Text = saveCalculator.CalculateAmountPaid().ToString("f2");
        finalBalanceFrameLabel.Text = saveCalculator.CalculateFutureValue().ToString("f2");
    }

    /*
	Method that execute the methods 'GetAndSetMonthlyDeposit' and 'GetAndSetPeriod'
    that validates each entry and set the attributes in the SavingCalculator class
    If each method returns true then continue and execute the method 'DisplayFutureValue'
	*/
    private void OnClickCalculateFutureValue(object sender, EventArgs e)
    {
        if (GetAndSetMonthlyDeposit() && GetAndSetPeriod())
        {
            DisplayFutureValue();
        }
    }
}