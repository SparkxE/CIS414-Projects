using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnStrategy: ScriptableObject {
    public abstract void Spawn(Transform origin);
}