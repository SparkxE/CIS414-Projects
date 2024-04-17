using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRaceState
{
    void Handle(RaceController controller);
}
