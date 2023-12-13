/* 
Lukas Jönsson
3/10-2023
*/

namespace Solution_Assignment_5;


/// <summary>
/// EventManager class
/// </summary>
public class EventManager
{
    /// <summary>
    /// The private attributes
    /// </summary>
    private double costPerParticipant;
    private double feePerParticipant;
    private string title;
    private ParticipantManager participantManager = new ParticipantManager();


    /// <summary>
    /// EventManager constructor
    /// </summary>
    public EventManager()
    {
        participantManager = new ParticipantManager();
    }

    /// <summary>
    /// Property with methods for Get and Set the attribute 'costPerParticipant'
    /// </summary>
    public double CostPerParticipant
    {
        get { return costPerParticipant; }
        set
        {
            // Implemented '>= 0.00' in order to have events with free entry
            if (value >= 0.00)
            {
                costPerParticipant = value;
            }
        }
    }

    /// <summary>
    /// Property with methods for Get and Set the attribute 'feePerParticipant'
    /// </summary>
    public double FeePerParticipant
    {
        get { return feePerParticipant; }
        set
        {
            if (value >= 0.00)
            {
                feePerParticipant = value;
            }
        }
    }

    /// <summary>
    /// Property with methods for Get and Set the attribute 'title'
    /// </summary>
    public string Title
    {
        get { return title; }
        set
        {
            if (ValidateString(value))
            {
                title = value;
            }
        }
    }

    /// <summary>
    /// Property with method for Get 'participantManager'
    /// </summary>
    public ParticipantManager Participants
    {
        get { return participantManager; }
    }

    /// <summary>
    /// Method that validate that string is not null or empty
    /// </summary>
    /// <param name="value">The string to validate</param>
    /// <returns>True if the string is not null or empty, otherwise false</returns>
    private bool ValidateString(string value)
    {
        return !string.IsNullOrEmpty(value);
    }

    /// <summary>
    /// Method that calculate and return the total event cost
    /// </summary>
    /// <returns>The total cost</returns>
    public double CalculateTotalCost()
    {
        return Participants.GetNumberOfParticipants * costPerParticipant;
    }

    /// <summary>
    /// Method that calculate and return the total event fee
    /// </summary>
    /// <returns>The total fee</returns>
    public double CalculateTotalFee()
    {
        return Participants.GetNumberOfParticipants * feePerParticipant;
    }

    /// <summary>
    /// Method that calculate and return the surplus/deficit, this method is
    /// implemented to separate the logic from the presentation. Another way
    /// could be to perform the calulcation in the 'MainForm' however this approach
    /// is more structured and consistent
    /// </summary>
    /// <returns>The surplus/deficit</returns>
    public double CalculateSurplusDeficit()
    {
        return (CalculateTotalFee() - CalculateTotalCost());
    }
}