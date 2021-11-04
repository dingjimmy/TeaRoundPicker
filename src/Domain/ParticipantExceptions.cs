using System.Runtime.Serialization;

namespace TeaRoundPicker.Domain;

public class DuplicateParticipantsException : Exception
{
    public DuplicateParticipantsException()
        : base("Two or more participants with the same name have been added. Please ensure participants have unique names.")
    {

    }
}

public class TooFewParticipantsException : Exception
{
    public TooFewParticipantsException()
        : base("No participants have been added. Please ensure at least two participants have been added.")
    {

    }
}
