using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class RaceController : MonoBehaviour 
{
    private IRaceState startState, stopState, endState;
    private RaceStateContext raceStateContext;
   

    public void StartRace(){
        this.raceStateContext.Transition(this.startState);
    }

    public void StopRace(){
        this.raceStateContext.Transition(this.stopState);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.raceStateContext = gameObject.AddComponent<RaceStateContext>();
        
        this.startState = gameObject.AddComponent<RaceStartState>();
        this.stopState = gameObject.AddComponent<RaceStopState>();
        this.endState = gameObject.AddComponent<RaceEndState>();

        this.raceStateContext.Transition(stopState);


    }
   
   


}
