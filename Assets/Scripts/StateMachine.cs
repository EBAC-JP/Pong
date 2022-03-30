using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {
    
    public static StateMachine instance;
    private enum States {
        MENU,
        PLAYING,
        RESET_BALL,
        END_GAME
    }
    private Dictionary<States, StateBase> _states;
    private StateBase _currentState;
    private States _current;

    void Awake() {
        instance = this;
        _states = new Dictionary<States, StateBase>();
        _states.Add(States.MENU, new StateMenu());
        _states.Add(States.PLAYING, new StatePlaying());
        _states.Add(States.RESET_BALL, new StateResetBall());
        _states.Add(States.END_GAME, new StateEndGame());

        SwitchState(States.MENU);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && (_current == States.MENU || _current == States.END_GAME)) {
            SwitchState(States.PLAYING);
        } else if(Input.GetKeyDown(KeyCode.Escape) && _current == States.END_GAME) {
            SwitchState(States.MENU);
        }
    }

    void SwitchState(States state, GameObject obj = null) {
        if (_currentState != null) _currentState.OnStateExit();
        _currentState = _states[state];
        _current = state;
        _currentState.OnStateEnter(obj);
    }

    public void ChangeStateToReset() {
        SwitchState(States.RESET_BALL);
    }

    public void ChangeStateToEnd(GameObject player) {
        SwitchState(States.END_GAME, player);
    }
}
