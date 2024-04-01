using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    List<Observer> observers = new List<Observer>();

    public void Attach(Observer anObserver)
    {
        observers.Add(anObserver);
    }
    public void Detach(Observer anObserver)
    {
        observers.Remove(anObserver);
    }
    public void NotifyObservers()
    {
        foreach (Observer observer in observers)
        {
            observer.Notify(this);
        }
    }
}
