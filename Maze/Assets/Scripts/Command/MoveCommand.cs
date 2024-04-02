using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : IMove //implements the Interface
{
    private string direction = "W";
    private GameObject aGameObject;

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
            // AGameObject.transform.position = AGameObject.transform.position + AGameObject.transform.forward;
            AGameObject.GetComponent<Rigidbody>().velocity = Vector3.forward.normalized * 7;
        }
        if (this.Direction == "A")
        {
            // AGameObject.transform.position = AGameObject.transform.position - AGameObject.transform.right;
            AGameObject.GetComponent<Rigidbody>().velocity = Vector3.left.normalized * 7;
        }
        if (this.Direction == "S")
        {
            // AGameObject.transform.position = AGameObject.transform.position - AGameObject.transform.forward;
            AGameObject.GetComponent<Rigidbody>().velocity = Vector3.back.normalized * 7;
        }
        if (this.Direction == "D")
        {
            // AGameObject.transform.position = AGameObject.transform.position + AGameObject.transform.right;
            AGameObject.GetComponent<Rigidbody>().velocity = Vector3.right.normalized * 7;
        }
    }

    public void UnExecute()
    {
        if (this.Direction == "W")
        {
            AGameObject.transform.position = AGameObject.transform.position - AGameObject.transform.forward;
        }
        if (this.Direction == "A")
        {
            AGameObject.transform.position = AGameObject.transform.position + AGameObject.transform.right;
        }
        if (this.Direction == "S")
        {
            AGameObject.transform.position = AGameObject.transform.position + AGameObject.transform.forward;
        }
        if (this.Direction == "D")
        {
            AGameObject.transform.position = AGameObject.transform.position - AGameObject.transform.right;
        }
    }
}
