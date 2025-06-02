using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTurret : Turret
{
    public float SlowAmount { get; set; } = 0.5f;
    public float Duration { get; set; } = 3f;

    public override void Attack(Enemy enemy)
    {
        enemy.ApplySlowness(SlowAmount, Duration);
    }
}
