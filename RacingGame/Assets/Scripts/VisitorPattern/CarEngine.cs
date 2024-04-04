using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour, ICarElement
{
    public float boost = 25.0f;
    public float defaultSpeed = 300.0f;
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    void OnGUI()
    {
       
        GUI.color = Color.black;
        GUI.Label(new Rect(25, 75, 200, 20), " car Boost: " + boost);
       
    }
}
