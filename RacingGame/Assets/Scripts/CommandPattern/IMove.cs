using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove
{
    public void Execute();
    public void UnExecute();
    string Direction{   //THIS DOESN'T WORK IN JAVA (probably won't matter lol)
        get;
    }
}
