namespace Domain;

/// <summary>
/// Represents an individual team member, who is participating in the tea round.
/// </summary>
public class Participant
{
    /// <summary>
    /// Gets the name of the participant.
    /// </summary>
    public string Name { get; }
 
    /// <summary>
    /// Creates a new instance of the <see cref="Participant"/> class.
    /// </summary>
    /// <param name="name">The name of the new participant.</param>
    /// <exception cref="ArgumentException"></exception>
    public Participant(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
        }

        Name = name;
    }
}
