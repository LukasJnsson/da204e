/* 
Lukas Jönsson
21/9-2023
*/

using System;
using System.Reflection;

namespace Solution_Assignment_4_PhoneBookApp;


/*
PhoneBook class
*/
public class PhoneBook
{
    /*
    The private attributes equal to string arrays
    */
    private string[] names = { "James", "Lars", "Kirk", "Robert", "Dave", "Taylor", "Chris", "Pat", "Nate", "Rami" };
    private string[] phoneNumbers = { "040-4441", "040-4442", "040-4443", "040-4444", "040-4445", "040-4440", "040-4446", "040-4447", "040-4448", "040-4449" };
    private string[,] contactList;

    /*
    Public constructor
    */
    public PhoneBook()
    {
        // One-dimensional array
        Console.WriteLine("One-dimensional array");

        // Display contact list
        GetContactList();

        // Line break
        Console.WriteLine();

        // Sort contact book by 'names'
        SortContactBookByNameOrNumber(names);
        GetContactList();

        // Line break
        Console.WriteLine();

        // Two-dimensional array
        Console.WriteLine("Two-dimensional array");

        // Populate the two-dimensional array 'contactList'
        int count = names.Length;
        contactList = new string[count, 2];
        FillTable();

        // Display contact table
        GetContactTable();

        // Line break
        Console.WriteLine();

        // Maintain the terminal window open
        Console.Read();
    }

    /*
    Method that displays the contact list
    */
    private void GetContactList()
    {
        /* 
        Iterate through the 'names' array
        Array index start with '0'
        'names.Length = 10' therefore need to use ' - 1 '
        */
        for (int index = 0; index <= names.Length - 1; index++)
        {
            // Map the element in each array with the same index
            Console.WriteLine(string.Format("{0, -10} {1, -10}", names[index], phoneNumbers[index]));
        }
    }

    /*
    Method that swap name and phone number index
    */
    private void SwapValues(int index)
    {
        // Swap name
        string nameHolder = names[index];
        names[index] = names[index + 1];
        names[index + 1] = nameHolder;

        // Swap phone number
        string numberHolder = phoneNumbers[index];
        phoneNumbers[index] = phoneNumbers[index + 1];
        phoneNumbers[index + 1] = numberHolder;
    }

    /*
    Method that sort contact book by name or phone number
    Implemented this more dynamic approach by adding the parameter 'arrayToSortBy'
    therefore the contact book can be sorted both by name or phone number
    */
    private void SortContactBookByNameOrNumber(string[] arrayToSortBy)
    {
        int position, index;
        int numOfContacts = arrayToSortBy.Length;

        for (position = 0; position < numOfContacts - 1; position++)
        {
            for (index = 0; index < numOfContacts - position - 1; index++)
            {
                int result = arrayToSortBy[index].CompareTo(arrayToSortBy[index + 1]);

                // Ascending order '1' or descending order '-1'
                if (result == 1)
                {
                    SwapValues(index);
                }
            }
        }
    }

    /*
    Method that populate the array 'contactList' with the elements from the
    'names' and 'phoneNumbers' arrays
    Since accessing each element with the 'row' index ' <array.Length> - 1 ' is
    not needed
    */
    private void FillTable()
    {
        for (int row = 0; row < names.Length; row++)
        {
            contactList[row, 0] = names[row];
            contactList[row, 1] = phoneNumbers[row];
        };
    }

    /*
    Method that display the contact table
    */
    private void GetContactTable()
    {
        int rows = contactList.GetLength(0);
        int columns = contactList.GetLength(1);

        for (int row = 0; row < rows; row++)
        {
            Console.Write(string.Format("{0, -10}", "Row " + row.ToString()));

            for (int col = 0; col < columns; col++)
            {
                Console.Write(string.Format("{0, -10}", contactList[row, col]));
            }
            // Add new line for each contact
            Console.WriteLine();
        }
    }
}