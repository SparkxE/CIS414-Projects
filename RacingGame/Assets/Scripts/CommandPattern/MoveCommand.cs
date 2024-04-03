using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : IMove //implements the Interface
{
    private string direction = "W";
    private GameObject aGameObject;
    private float inputSpeed;
    private bool movingForward = true;

    public string Direction { get { return this.direction; } }

    public GameObject AGameObject { get { return this.aGameObject; } }

    public MoveCommand(string aDirection, GameObject anObject, float speed)
    {
        this.direction = aDirection;
        this.aGameObject = anObject;
        this.inputSpeed = speed;
    }
    public void Execute()
    {  //main important thing!!
        if (this.Direction == "W")
        {
            movingForward = true;
            AGameObject.GetComponent<Rigidbody>().AddForce(AGameObject.transform.forward * inputSpeed);
        }
        if (this.Direction == "A")
        {
            if (movingForward == false)
            {
                //invert turning if moving backwards to replicate real-world reversing
                AGameObject.transform.RotateAround(AGameObject.transform.position + new Vector3(2, 0, -2), Vector3.up, inputSpeed);
            }
            else
            {
                //turn normally if not moving backwards
                AGameObject.transform.RotateAround(AGameObject.transform.position - new Vector3(2, 0, 2), Vector3.up, -inputSpeed);
            }
        }
        if (this.Direction == "S")
        {
            movingForward = false;
            AGameObject.GetComponent<Rigidbody>().AddForce(AGameObject.transform.forward * -inputSpeed);
        }
        if (this.Direction == "D")
        {
            if (movingForward == false)
            {
                //invert turning if moving backwards to replicate real-world reversing
                AGameObject.transform.RotateAround(AGameObject.transform.position - new Vector3(2, 0, 2), Vector3.up, -inputSpeed);
            }
            else
            {
                //turn normally if not moving backwards
                AGameObject.transform.RotateAround(AGameObject.transform.position + new Vector3(2, 0, -2), Vector3.up, inputSpeed);
            }
        }
    }

    public void UnExecute()
    {
        AGameObject.transform.position = Vector3.zero;  //simplified for the sake of consistency
    }
}
