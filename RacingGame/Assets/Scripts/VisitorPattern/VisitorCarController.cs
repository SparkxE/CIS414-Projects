using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorCarController : MonoBehaviour
{
    private List<ICarElement> CarElements = new List<ICarElement>();
    void Start()
    {
        CarElements.Add(gameObject.AddComponent<CarEngine>());
        
    }

    public void Accept(IVisitor visitor)
    {
        foreach (ICarElement element in CarElements)
        {
            element.Accept(visitor);
        }
    }

}
