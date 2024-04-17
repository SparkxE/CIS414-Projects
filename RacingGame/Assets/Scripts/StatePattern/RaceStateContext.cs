using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceStateContext : MonoBehaviour
{
    private IRaceState currentState;
    private RaceController raceController;

    public IRaceState CurrentState{
        get{
            return this.currentState;
        }
        set{
            this.currentState = value;
        }
    }

    //constructor
    public RaceStateContext(RaceController raceController){
        this.raceController = raceController;
    }

    public void Transition(){
        CurrentState.Handle(raceController);
    }

    public void Transition(IRaceState state){
        this.CurrentState = state;
        CurrentState.Handle(raceController);
    }
}
