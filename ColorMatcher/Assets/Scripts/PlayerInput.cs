using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : Singleton<PlayerInput>
{
    private int totalScore = 0;
    private List<IFlip> flips = new List<IFlip>();
    // Update is called once per frame
    void Update()
    {
        Flip();
    }

    private void Flip()
    {
        if (Input.anyKeyDown)   //check if a Keyboard key has been pressed
        {
            //assign pressed key to new FlipCommand object's Choice value
            char inputChoice = Input.inputString.ToCharArray()[0];
            FlipCommand aCommand = new FlipCommand(inputChoice);

            if (aCommand.Selection == null) //check if a Tile object exists in scene before adding aCommand to Flips list
            {
                Debug.Log("Invalid selection");
            }
            else
            {
                //if Tile object found, add aCommand to Flips and execute Command
                flips.Add(aCommand);
                aCommand.Execute();

                //if Flips has 2 FlipCommands in it, check if the colors match (via material names)
                if (flips.Count == 2)
                {
                    if (flips[0].Selection == flips[1].Selection)
                    {
                        Debug.Log("Same Tile");
                        Invoke("UnFlip", 1f);
                    }

                    else if (flips[0].Selection.GetComponent<Renderer>().material.name == flips[1].Selection.GetComponent<Renderer>().material.name)
                    {
                        //if material names match, destroy the chosen Tiles & clear Flips list
                        Debug.Log("Tiles Match");
                        totalScore++;
                        Invoke("DestroyTiles", 1f);     //Invoke() function allows for slight delay in operation so the user can see what's happening
                    }
                    else
                    {
                        //if material names don't match, UnExecute on each Tile & clear Flips list
                        Debug.Log("Tiles don't match");
                        Invoke("UnFlip", 1f);   //Invoke() function allows for slight delay in operation so the user can see what's happening
                    }
                }
            }
        }
    }

    private void DestroyTiles()
    {
        foreach (FlipCommand flip in flips)
        {
            Destroy(flip.Selection);    //destroy the selected Tiles
            flip.Selection.GetComponent<TileCube>().ReturnToPool();
        }
        flips.Clear();
    }

    private void UnFlip()
    {
        foreach (FlipCommand flip in flips)
        {
            flip.UnExecute();  //Execute "flips" tiles (disables child TileShadow object), UnExecute re-enables TileShadow on each selected Tile
        }
        flips.Clear();
    }


    private void OnGUI()
    {
        if (GUILayout.Button("Next Scene"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        GUI.color = Color.white;
        GUI.Label(new Rect(1, 25, 200, 40), "Current Score: " + totalScore);
    }
}
