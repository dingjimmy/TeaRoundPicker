using Spectre.Console;
using TeaRoundPicker.Domain;

List<Participant> _particpants = new List<Participant>();
RandomPicker _picker = new RandomPicker();
bool readyToPick = false;

while (!readyToPick)
{
    var name = AnsiConsole.Ask<string>("What is the name of the participant?");

    if (string.IsNullOrWhiteSpace(name))
    {
        AnsiConsole.MarkupLine($"[red]That was not a valid name. Please try again.[/]");
        continue;
    }

    var newParticipant = new Participant(name);
    
    if (_particpants.Contains(newParticipant))
    {
        AnsiConsole.MarkupLine($"[red]{newParticipant.Name} has already been added. Please try again.[/]");
        continue;
    }

    _particpants.Add(newParticipant);

    if (_particpants.Count >= 2)
    {
        readyToPick = !AnsiConsole.Confirm("Add another participant?");
    }
}

var pickedParticipant = _picker.PickParticipant(_particpants);

AnsiConsole.MarkupLine($"And the winner is [green]{pickedParticipant.Name}[/]!!!");

Console.Read();