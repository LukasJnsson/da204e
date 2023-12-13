/* 
Lukas Jönsson
21/9-2023
*/

using System;
namespace Solution_Assignment_4_PartyOrganizer;


/*
PartyManager class
*/
public class PartyManager
{
    /*
    The private attributes
    */
    private double costPerGuest;
    private double feePerGuest;
    private string[] guestList;


    /*
    Public constructor
    The parameter 'maxNumberOfGuest' set the maximum length of the array 'guestList'
    */
    public PartyManager(int maxNumberOfGuest)
    {
        guestList = new string[maxNumberOfGuest];
    }

    /*
    Property with methods for Get and Set 'costPerGuest'
    */
    public double CostPerGuest
    {
        get { return costPerGuest; }
        set
        {
            if (value > 0.0)
            {
                costPerGuest = value;
            }
        }
    }

    /*
    Property with methods for Get and Set 'feePerGuest'
    */
    public double FeePerGuest
    {
        get { return feePerGuest; }
        set
        {
            if (value > 0.0)
            {
                feePerGuest = value;
            }
        }
    }

    /*
    Property with method for Get the maximum number of guests
    */
    public int MaxNumberOfGuests
    {
        get { return guestList.Length; }
    }

    /*
    Method that return the number of registered guests
    */
    private int GetNumberOfGuests()
    {
        int numberOfGuest = 0;

        for (int index = 0; index < guestList.Length; index++)
        {
            if (!string.IsNullOrEmpty(guestList[index]))
            {
                // Increment if the index is not null or empty
                numberOfGuest++;
            }
        }
        return numberOfGuest;
    }

    /*
    Method that return the guest list with the registered guests
    */
    public string[] GetGuestList()
    {
        int numberOfGuest = GetNumberOfGuests();

        // New array with the guests
        string[] guests = new string[numberOfGuest];

        for (int index = 0, registerdIndex = 0; index < guestList.Length; index++)
        {
            if (!string.IsNullOrEmpty(guestList[index]))
            {
                guests[registerdIndex++] = guestList[index];
            }
        }
        return guests;
    }

    /*
    Method that return the first available index in the 'guestList'
    */
    private int FindAvailableIndex()
    {
        // The default index if no availability ('guestList' full)
        int availableIndex = -1;

        // Iterate through the 'guestList' array
        for (int index = 0; index < guestList.Length; index++)
        {
            if (string.IsNullOrEmpty(guestList[index]))
            {
                // Set the 'availableIndex' equal the available index
                availableIndex = index;
                break;
            }
        }
        return availableIndex;
    }

    /*
    Method that validates and return if there is an element (guest) on the index
    */
    private bool ValidateIndexElement(int index)
    {
        return !string.IsNullOrEmpty(guestList[index]);
    }

    /*
    Method that move the array elements one step to the left
    */
    private void MoveArrayElementsOneStep(int index)
    {
        for (int i = index + 1; i < guestList.Length; i++)
        {
            // Move one step to the left
            guestList[i - 1] = guestList[i];

            // Empty the element on the index
            guestList[i] = string.Empty;
        }
    }

    /*
    Method that format the full name of the guest by capitalizing the last name
    */
    private string GetFullName(string firstName, string lastName)
    {
        return $"{lastName.ToUpper()}, {firstName}";
    }

    /*
    Method that add guest
    */
    public bool AddGuest(string firstName, string lastName)
    {
        /*
        By setting 'guestAdded' to false the else statement is excluded instead
        the 'guestAdded' gets modified in the if statement
        */
        bool guestAdded = false;
        int availableIndex = FindAvailableIndex();

        if (availableIndex != -1)
        {
            guestList[availableIndex] = GetFullName(firstName, lastName);
            guestAdded = true;
        }
        return guestAdded;
    }

    /*
    Method that delete guest
    */
    public bool DeleteGuest(int index)
    {
        bool guestDeleted = false;

        if (ValidateIndexElement(index))
        {
            guestList[index] = string.Empty;
            MoveArrayElementsOneStep(index);
            guestDeleted = true;
        }
        return guestDeleted;
    }

    /*
    Method that calculate and return the total cost
    */
    public double GetTotalCost()
    {
        return (CostPerGuest * GetNumberOfGuests());
    }

    /*
    Method that calculate and return the total fees
    */
    public double GetTotalFees()
    {
        return (FeePerGuest * GetNumberOfGuests());
    }

    /*
    Method that calculate and return the surplus/deficit
    */
    public double GetSurplusDeficit()
    {
        return (GetTotalFees() - GetTotalCost());
    }
}