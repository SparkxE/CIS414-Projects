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
    public FlipCommand(char aChoice){   //Constructor
        this.choice = aChoice;
        this.selection = GameObject.Find("Tile" + Choice);  //find Tile with name matching Choice rather than passing the object in
    }
    public void Execute(){
        Selection.transform.GetChild(0).gameObject.SetActive(false);    //Set the first child Object found (should be TileShadow for all tiles) to InActive, revealing Selection's color
    }
    public void UnExecute(){
        Selection.transform.GetChild(0).gameObject.SetActive(true);     //Set the first child Object found (should be TileShadow for all tiles) to Active, hiding Selection's color
    }
}
