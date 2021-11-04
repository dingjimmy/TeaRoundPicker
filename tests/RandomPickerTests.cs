using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

    [Fact]
    public void Fewer_than_two_participants_is_invalid()
    {
        // arrange participants list with one participant
        var participants = new[]
        {
            new Participant("Fred"),
        };
        var picker = new RandomPicker();

        // assert that a 'too few participants' exception is thrown
        Assert.Throws<TooFewParticipantsException>(() => picker.PickParticipant(participants));
    }

    [Fact]
    public void A_null_participant_list_is_invalid()
    {
        // arrange a null participants list
        List<Participant>? participants = null;
        var picker = new RandomPicker();

        // assert that an 'agrument null' exception is thrown. Suppressing compiler warning CS8640 as we are passing a null reference by design!
#pragma warning disable CS8604 //
        Assert.Throws<ArgumentNullException>(() => picker.PickParticipant(participants));
#pragma warning restore CS8604 
    }
}