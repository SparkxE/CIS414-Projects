using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSpeedBoostVisitor : ShootingVisitor
{
    private float shootingSpeedBoost;

    public ShootingSpeedBoostVisitor(float speedBoost)
    {
        shootingSpeedBoost = speedBoost;
    }

    public void Visit(UserController player)
    {
        player.ApplyShootingSpeedBoost(shootingSpeedBoost);
    }
}
