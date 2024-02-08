using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFlip
{
    public void Execute();
    public void UnExecute();
    char Choice{
        get; 
    }
}
