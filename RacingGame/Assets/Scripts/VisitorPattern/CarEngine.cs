using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour, ICarElement
{
  
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
   
}
