namespace TeaRoundPicker.Domain;

/// <summary>
/// Represents the logic for picking a participant.
/// </summary>
public interface IPicker
{
    Participant PickParticipant(IList<Participant> participants);
}
