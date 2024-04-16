using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorCarController : MonoBehaviour
{
    private List<ICarElement> carElements = new List<ICarElement>();
    void Start()
    {
        carElements.Add(gameObject.AddComponent<CarEngine>());
      
    }

    public void Accept(IVisitor visitor)
    {
        foreach ( ICarElement element in carElements)
        {
            element.Accept(visitor);
        }
    }
}
