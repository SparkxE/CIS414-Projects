using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffect
{
    public string EffectName{get; set;}

    public void Initialize();
}
