using TeaRoundPicker.Domain;
using Xunit;

namespace TeaRoundPicker.Tests;

public class RandomPickerTests
{
    [Fact]
    public void Pick_a_participant()
    {
        // arrange
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
}