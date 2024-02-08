using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCommand : IFlip
{
    private char choice;
    private GameObject selection;
    public char Choice{
        get{
            return this.choice;
        }
    }
    public FlipCommand(char aChoice){
        
    }
    public void Execute(){

    }
    public void UnExecute(){

    }
}
