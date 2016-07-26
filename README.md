This is the state machine implementation I wrote to use it with Unity. I recommend to write the update, enter and leave methods of the different states as methods of the MonoBehaviour to have named methods with easy access to all of the fields of the MonoBehaviour. The appropriate methods will be called when the state machine is updated.

##Instructions:

The state machine and the states should be fields of the MonoBehaviour:
```
public class Bob : MonoBehaviour {

	State_machine state_machine;
	
    State default_state;
    State special_state;
```

Write methods, which will be called when a specific state will be entered, left or updated:
```
	void update_default () { 
		//do stuff
	}
	
	void enter_default () { 
		//do stuff
	}
	
	void leave_default () { 
		//do stuff
	}
	
	void update_special () { 
		//do stuff
	}
```

Initialize the state machine and the states:
```
	void Start () {
		default_state = new State(update_default, enter_default, leave_default);
        swing_state = new State(update_special, null, null);

        state_machine = new State_machine(normal_state);
	}
```

Update the state machine every frame:
```
	void Update () {
		state_machine.update();
	}
```

Change and query the current state with the state field of the state machine:
```
		state_machine.state = special_state;
		
		if (state_machine.state == special_state) {
			//do stuff
		}
```

	
	