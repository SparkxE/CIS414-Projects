using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ShootingVisitor
{
    void Visit(UserController player);
}
