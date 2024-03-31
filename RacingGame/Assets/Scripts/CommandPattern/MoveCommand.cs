using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : IMove //implements the Interface
{
    private string direction = "W";
    private GameObject aGameObject;
    private float accelSpeed;
    private float turnSpeed;

    public string Direction { get { return this.direction; } }

    public GameObject AGameObject { get { return this.aGameObject; } }

    public MoveCommand(string aDirection, GameObject anObject)
    {
        this.direction = aDirection;
        this.aGameObject = anObject;
    }
    public void Execute()
    {  //main important thing!!
        if (this.Direction == "W")
        {
            AGameObject.GetComponent<Rigidbody>().velocity = AGameObject.transform.forward * 3;
        }
        if (this.Direction == "A")
        {
            AGameObject.transform.RotateAround(AGameObject.transform.position, Vector3.up, -1f);
        }
        if (this.Direction == "S")
        {
            AGameObject.GetComponent<Rigidbody>().velocity = AGameObject.transform.forward * -3;
        }
        if (this.Direction == "D")
        {
            AGameObject.transform.RotateAround(AGameObject.transform.position, Vector3.up, 1f);
        }
    }

    public void UnExecute()
    {
        AGameObject.transform.position = Vector3.zero;  //simplified for the sake of consistency
    }
}
