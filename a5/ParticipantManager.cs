/* 
Lukas Jönsson
3/10-2023
*/

namespace Solution_Assignment_5;


/// <summary>
/// ParticipantManager class
/// </summary>
public class ParticipantManager
{
    /// <summary>
    /// Create new collection object that will store the participants
    /// </summary>
    private List<Participant> participants;


    /// <summary>
    /// ParticipantManager constructor
    /// </summary>
    public ParticipantManager()
    {
        participants = new List<Participant>();
    }

    /// <summary>
    /// Property with method for Get the number of participants in the collection
    /// </summary>
    public int GetNumberOfParticipants
    {
        get { return participants.Count; }
    }

    /// <summary>
    /// Method that add participant
    /// </summary>
    /// <param name="participant">The participant object</param>
    /// <returns>True if participant added, otherwise false</returns>
    public bool AddParticipant(Participant participant)
    {
        bool isAdded = false;

        if (participant != null)
        {
            participants.Add(participant);
            isAdded = true;
        }
        return isAdded;
    }

    /// <summary>
    /// Method that update participant
    /// </summary>
    /// <param name="participant">The participant object</param>
    /// <param name="index">The index of the participant in the collection</param>
    /// <returns>True if participant updated, otherwise false</returns>
    public bool UpdateParticipant(Participant participant, int index)
    {
        bool isUpdated = false;

        if ((participant != null) && ValidateIndex(index))
        {
            participants[index] = participant;
            isUpdated = true;
        }
        return isUpdated;
    }

    /// <summary>
    /// Method that delete participant
    /// </summary>
    /// <param name="index">The index of the participant in the collection</param>
    /// <returns>True if participant deleted, otherwise false</returns>
    public bool DeleteParticipant(int index)
    {
        bool isDeleted = false;

        if(ValidateIndex(index))
        {
            participants.RemoveAt(index);
            isDeleted = true;
        }
        return isDeleted;
    }

    /// <summary>
    /// Method that validate index
    /// </summary>
    /// <param name="index">The index in the collection</param>
    /// <returns>True if the index is in the range of the collection, otherwise false</returns>
    private bool ValidateIndex(int index)
    {
        return (index >= 0) && (index < GetNumberOfParticipants);
    }

    /// <summary>
    /// Method that return the participant on the specific index in the collection
    /// </summary>
    /// <param name="index">The index of the participant in the collection</param>
    /// <returns>The participant object</returns>
    public Participant GetParticipant(int index)
    {
        if (ValidateIndex(index))
        {
            return participants[index];
        }
        return null;
    }

    /// <summary>
    /// Method that return the participants in the collection
    /// </summary>
    /// <returns>Array with the participants in the collection</returns>
    public string[] GetParticipants()
    {
        string[] participantsArr = new string[GetNumberOfParticipants];

        int index = 0;

        /*
        Iterate through the participants collection and append the participants
        to the array. Each participant is represented by the returned string
        from the overridden ToString() method
        */
        foreach (Participant participant in participants)
        {
            participantsArr[index++] = participant.ToString();
        }
        return participantsArr;
    }
}