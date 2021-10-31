namespace TeaRoundPicker.Domain;

/// <summary>
/// Represents the logic for randomly picking a participant.
/// </summary>
public class RandomPicker : IPicker
{
    /// <summary>
    /// Chooses a person from a list of participants.
    /// </summary>
    /// <param name="participants">The list of participants to choose from.</param>
    public Participant PickParticipant(IList<Participant> participants)
    {
        if (HasDuplicateParticipants(participants))
        {
            throw new DuplicateParticipantsException();
        }

        var rng = new Random()
            ;
        var i = rng.Next(0, participants.Count-1);

        return participants[i];
    }

    private bool HasDuplicateParticipants(IList<Participant> participants)
    {
        return participants.Distinct().Count() != participants.Count;
    }
}
