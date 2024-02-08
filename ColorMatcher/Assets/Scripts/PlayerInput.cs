using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private List<IFlip> flips = new List<IFlip>();
    // Update is called once per frame
    void Update()
    {
        Flip();
    }

    private void Flip(){
        if(Input.anyKeyDown){
            char inputChoice = Input.inputString.ToCharArray()[0];
            FlipCommand aCommand = new FlipCommand(inputChoice);
            if(aCommand.Selection == null){
                Debug.Log("Invalid selection");
            }
            else{
                flips.Add(aCommand);
                if(flips.Count == 2){
                    foreach(FlipCommand flip in flips){
                        flip.Execute();
                    }
                    if(flips[0].Selection.GetComponent<Renderer>().material == flips[1].Selection.GetComponent<Renderer>().material){
                        Invoke("DestroyTiles", 1f);
                        flips.Clear();    //<-- Not sure if doing this here will interrupt the DestroyTiles function
                    }
                    else{
                        foreach(FlipCommand flip in flips){
                            flip.UnExecute();
                        }
                    }
                }
            }
        }
    }

    private void DestroyTiles(){
        foreach(FlipCommand flip in flips){
            Destroy(flip.Selection);
        }
        //flips.Clear();
    }
}
