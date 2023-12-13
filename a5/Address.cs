/* 
Lukas Jönsson
3/10-2023
*/

namespace Solution_Assignment_5;


/// <summary>
/// Address class
/// </summary>
public class Address
{
    /// <summary>
    /// The private attributes
    /// </summary>
    private string city;
    private Countries country;
    private string street;
    private string zipCode;


    /// <summary>
    /// Address constructor
    /// </summary>
    public Address()
    {
    }

    /// <summary>
    /// Address constructor
    /// <param name="city">The address city</param>
    /// <param name="country">The address country</param>
    /// <param name="street">The address street</param>
    /// <param name="zipCode">The address zipCode</param>
    /// </summary>
    public Address(string city, Countries country, string street, string zipCode)
    {
        this.city = city;
        this.country = country;
        this.street = street;
        this.zipCode = zipCode;
    }

    /// <summary>
    /// Property with methods for Get and Set the attribute 'city'
    /// </summary>
    public string City
    {
        get { return city; }
        set
        {
            if (ValidateString(value))
            {
                city = value;
            }
        }
    }

    /// <summary>
    /// Property with methods for Get and Set the attribute 'country'
    /// </summary>
    public Countries Country
    {
        get { return country; }
        set { country = value; }
    }

    /// <summary>
    /// Property with methods for Get and Set the attribute 'street'
    /// </summary>
    public string Street
    {
        get { return street; }
        set
        {
            if (ValidateString(value))
            {
                street = value;
            }
        }
    }

    /// <summary>
    /// Property with methods for Get and Set the attribute 'zipCode'
    /// </summary>
    public string ZipCode
    {
        get { return zipCode; }
        set
        {
            if (ValidateString(value))
            {
                zipCode = value;
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
    /// Method that return the country in string format
    /// The 'Replace()' method replace all '_' characters with a space
    /// </summary>
    /// <returns>The country string</returns>
    private string GetCountryString()
    {
        return country.ToString().Replace("_", " ");
    }

    /// <summary>
    /// Method that override the default 'ToString' method by implementing the specified
    /// format for the address
    /// </summary>
    /// <returns>The address string</returns>
    public override string ToString()
    {
        return $"{street} ({zipCode}) {city}, {GetCountryString()}";
    }
}