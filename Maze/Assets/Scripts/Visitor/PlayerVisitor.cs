using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerVisitor
{
    void Visit(UserController player);
}
