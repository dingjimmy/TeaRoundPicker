import React from 'react'
import ReactDOM from 'react-dom'

export default class Picker extends React.Component<PickerProps, PickerState> {

    constructor(props : PickerProps) {
        super(props);
        this.state = { NewParticipant: '', Participants: [] }
    }

    render() {
        return (
            <div>
                <h1>Welcome to the tea round picker. Shall we begin...</h1>
                <input id="newParticipant" type="text" onChange={this.newParticpantChanged} value={this.state.NewParticipant} />
                <button onClick={this.addParticipant}>Add Participant</button>
                <ul>
                    {this.state.Participants.map(p => (<li>{p.name}</li>))}
                </ul>
                <div>
                    <button onClick={this.pickParticipant}>Pick!</button>
                    <button onClick={this.clearParticipants}>Reset</button>
                </div >
            </div >
        );
    }

    // Updates the component state when user changes new participant name
    newParticpantChanged = (e: React.ChangeEvent<HTMLInputElement>) => {
        this.setState({ NewParticipant: e.target.value})   
    };

    // Adds a new name to the list of participants
    addParticipant = (e: React.MouseEvent<HTMLButtonElement>) => {
        e.preventDefault();

        if (this.state.NewParticipant.length == 0) {
            return;
        }

        let newParticipant: Participant = new Participant();
        newParticipant.name = this.state.NewParticipant;
        this.state.Participants.push(newParticipant);

        this.setState({ NewParticipant: '' });
    }

    // Resets component state back to default (i.e. empty} values
    clearParticipants = (e: React.MouseEvent<HTMLButtonElement>) => {
        this.setState({ NewParticipant: '', Participants: [] });
    }

    // Picks a participant to make the tea!
    pickParticipant = (e: React.MouseEvent<HTMLButtonElement>) => {

        
    }
}

class Participant {
    name : string

    constructor() {
        this.name = '';
    }
}

interface PickerProps {

}

interface PickerState {
    NewParticipant: string;
    Participants: Participant[];
}