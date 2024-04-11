using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    private IRaceState startState, stopState; 
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
        this.raceStateContext = new RaceStateContext(this);
        
        this.startState = gameObject.AddComponent<RaceStartState>();
        this.stopState = gameObject.AddComponent<RaceStopState>();

        this.raceStateContext.Transition(stopState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
