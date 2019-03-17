using System;

namespace raveaf.state_machine {

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

            if (state != null)
                execute_action(state.update_action);

            //checking whether the state was changed by the update actions
            check_state_change();        
        }

        void check_state_change() {
            if (state != last_state) {

                if (last_state != null)    
                    execute_action(last_state.exit_action);   
                                 
                execute_action(state.enter_action);     
                last_state = state;   
            }
        }

        void execute_action(Action action) {
            if (action != null) {
                action();
            }
        }
    }

    public  class State {
    
        public Action enter_action;  
        public Action update_action;
        public Action exit_action;          

        public State(Action update_action = null, Action enter_action = null, Action exit_action = null) {                    
            this.update_action = update_action;
            this.enter_action = enter_action;
            this.exit_action = exit_action;            
        }
    }
}
