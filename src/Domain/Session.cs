namespace TeaRoundPicker.Domain
{
    public class Session
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public List<Participant> Participants { get; set; } = new List<Participant> { };

        public Participant? PickedParticipant { get; set; }

        public Session(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException($"'{nameof(title)}' cannot be null or whitespace.", nameof(title));
            }

            Id = Guid.NewGuid();
            Title = title;
        }
    }
}
