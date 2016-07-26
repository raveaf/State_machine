using System;
using System.Collections.Generic;

namespace raweaf.state_machine {

    public class State_machine {

        public State state;
        public State last_state;

        public State_machine() {}

        public State_machine(State starting_state) {
            state = starting_state;
        }

        public void update() {
            //checking whether the state was changed outside of the state machine
            check_state_change();                       

            //there might be no current state, because the state machine has just been initialized
            if (state != null)
                execute_actions(state.update_actions);

            //checking whether the state was changed by the update actions
            check_state_change();        
        }

        void check_state_change() {
            if (state != last_state) {

                //there might be no last state, because the state machine has just been initialized
                if (last_state != null)    
                    execute_actions(last_state.exit_actions);   
                                 
                execute_actions(state.enter_actions);     
                last_state = state;   
            }
        }

        void execute_actions(List<Action> actions) {
            for (int i = 0; i < actions.Count; i++) {
                actions[i]();                    
            }            
        }
    }

    public  class State {
    
        public List<Action> enter_actions = new List<Action>();  
        public List<Action> update_actions = new List<Action>();  
        public List<Action> exit_actions = new List<Action>();  

        public State(Action[] update_actions = null, Action[] enter_actions = null, Action[] exit_actions = null) {            
            if (enter_actions != null) 
                this.enter_actions.AddRange(enter_actions);                    

            if (update_actions != null) 
                this.update_actions.AddRange(update_actions);            
        
            if (exit_actions != null) 
                this.exit_actions.AddRange(exit_actions);                 
        }

        public State(Action update_action = null, Action enter_action = null, Action exit_action = null) {        
            if (enter_action != null)
                enter_actions.Add(enter_action);

            if (update_action != null)
                update_actions.Add(update_action);

            if (exit_action != null)
                exit_actions.Add(exit_action);    
        }
    }
}