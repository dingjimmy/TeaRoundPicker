using TeaRoundPicker.Domain;
using Xunit;

namespace TeaRoundPicker.Tests;

public class RandomPickerTests
{
    [Fact]
    public void Pick_one_person_from_a_list_of_participants()
    {
        // arrange participants list
        var participants = new[]
        {
            new Participant("Fred"),
            new Participant("Barney"),
            new Participant("Wilma"),
            new Participant("Betty")
        };
        var picker = new RandomPicker();

        // act
        var pickedParticipant = picker.PickParticipant(participants);

        // assert that the picked participant is from the original list of participants
        Assert.Contains(pickedParticipant, participants);
    }

    [Fact]
    public void Duplicate_participants_are_invalid()
    {
        // arrange participants list to contain duplicates
        var participants = new[]
        {
            new Participant("Fred"),
            new Participant("Barney"),
            new Participant("Fred"),
            new Participant("Betty")
        };
        var picker = new RandomPicker();

        // assert that a 'duplicate participant' exception is thrown
        Assert.Throws<DuplicateParticipantsException>(() => picker.PickParticipant(participants));
    }
}