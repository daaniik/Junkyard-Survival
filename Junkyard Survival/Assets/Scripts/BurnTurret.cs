using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnTurret : Turret
{
    public float BurnDamagePerSecond { get; set; } = 5f;
    public float BurnDuration { get; set; } = 4f;

    public override void Attack(Enemy enemy)
    {
        enemy.ApplyBurn(BurnDamagePerSecond, BurnDuration);
    }
}
