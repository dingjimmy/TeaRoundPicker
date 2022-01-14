
class Participant {
    name: string;
}

interface PickerState {
    NewParticipant: string;
    Participants: Participant[];
}

//class Picker extends React.Component<Participant> {

//    constructor(props: Participant) {
//        super(props);
//        this.state = { items: [], text: '' };
//        this.handleChange = this.handleChange.bind(this);
//        this.handleSubmit = this.handleSubmit.bind(this);
//    }

//    render() {
//        return (<h3>This Picker React Component</h3>);
//    }
//}

class Picker extends React.Component<{}, PickerState> {

    constructor() {  
        super({});
        //this.handleNewParticpantChange = this.handleNewParticpantChange.bind(this);
        //this.handleSubmit = this.handleSubmit.bind(this);
    }

    render() {
        return (
            <div>
                <input id="newParticipant" type="text" onChange={this.handleNewParticpantChange} value={this.state.NewParticipant} />
                <button>Add Participant</button>

                <div>
                    <button ={this.pickParticipant}>Pick!</button>
                </div >
            </div>
        );
    }

    handleNewParticpantChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        //this.setState()
    };

    pickParticipant = (e: React.ChangeEvent<HTMLButtonElement>) => {

        e.preventDefault();

        if (this.state.NewParticipant.length == 0) {
            return;
        }

        let newParticipant: Participant = new Participant();
        newParticipant.name = this.state.NewParticipant;
        this.state.Participants.push(newParticipant);
    }
    
}

ReactDOM.render(
    <Picker />,
    document.getElementById('picker_container')
);