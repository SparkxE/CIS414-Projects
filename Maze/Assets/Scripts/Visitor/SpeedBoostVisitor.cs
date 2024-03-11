using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostVisitor : PlayerVisitor
{
    private float speedBoostAmount;

    public SpeedBoostVisitor(float boostAmount)
    {
        speedBoostAmount = boostAmount;
    }

    public void Visit(UserController player)
    {
        player.ApplySpeedBoost(speedBoostAmount);
    }
}

