namespace Domain;

/// <summary>
/// Represents the logic for randomly picking a participant.
/// </summary>
public class RandomPicker : IPicker
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="participants"></param>
    public Participant PickParticipant(IList<Participant> participants)
    {
        var rng = new Random();
        var i = rng.Next(0, participants.Count-1);

        return participants[i];
    }
}
