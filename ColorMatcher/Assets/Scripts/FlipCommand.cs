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
    public GameObject Selection{
        get{
            return this.selection;
        }
    }
    public FlipCommand(char aChoice){
        this.choice = aChoice;
        this.selection = GameObject.Find("Tile" + Choice);
    }
    public void Execute(){
        Selection.transform.GetChild(0).gameObject.SetActive(false);
    }
    public void UnExecute(){
        Selection.transform.GetChild(0).gameObject.SetActive(true);
    }
}
