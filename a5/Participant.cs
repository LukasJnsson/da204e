/* 
Lukas Jönsson
3/10-2023
*/

namespace Solution_Assignment_5;


/// <summary>
/// Participant class
/// </summary>
public class Participant
{
    /// <summary>
    /// The private attributes
    /// Each participant 'has an attribute equal an instance of the Address class'
    /// </summary>
    private Address address;
    private string firstName;
    private string lastName;


    /// <summary>
    /// Participant constructor
    /// </summary>
    public Participant()
    {
        address = new Address();
    }

    /// <summary>
    /// Property with methods for Get and Set the attribute 'address'
    /// </summary>
    public Address Address
    {
        get { return address; }
        set { address = value; }
    }

    /// <summary>
    /// Property with methods for Get and Set the attribute 'firstName'
    /// </summary>
    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (ValidateString(value))
            {
                firstName = value;
            }
        }
    }

    /// <summary>
    /// Property with methods for Get and Set the attribute 'lastName'
    /// </summary>
    public string LastName
    {
        get { return lastName; }
        set
        {
            if (ValidateString(value))
            {
                lastName = value;
            }
        }
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
    /// Method that override the default 'ToString' method by implementing the specified
    /// format for the participant
    /// </summary>
    /// <returns>The participant string</returns>
    public override string ToString()
    {
        return string.Format("{0} {1, -10} {2}", firstName, lastName, address.ToString());
    }
}