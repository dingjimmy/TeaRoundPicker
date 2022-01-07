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
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="TooFewParticipantsException"/>
    /// <exception cref="DuplicateParticipantsException"/>
    public Participant PickParticipant(IList<Participant> participants)
    {
        if (participants is null)
        {
            throw new ArgumentNullException(nameof(participants));
        }

        if (HasToFewParticipants(participants))
        {
            throw new TooFewParticipantsException();
        }

        if (HasDuplicateParticipants(participants))
        {
            throw new DuplicateParticipantsException();
        }

        return PickParticipant_Internal(participants);
    }

    private static Participant PickParticipant_Internal(IList<Participant> participants)
    {
        var rng = new Random();
        var i = rng.Next(0, participants.Count - 1);

        return participants[i];
    }

    private static bool HasToFewParticipants(IList<Participant> participants)
    {
        return !(participants.Count > 1);
    }

    private static bool HasDuplicateParticipants(IList<Participant> participants)
    {
        return participants.Distinct().Count() != participants.Count;
    }
}
