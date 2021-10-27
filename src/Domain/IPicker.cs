
namespace Domain;

public interface IPicker
{
    Participant PickParticipant(IEnumerable<Participant> participants);
}
