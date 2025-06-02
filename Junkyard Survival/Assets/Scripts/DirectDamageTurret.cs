using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectDamageTurret : Turret
{
    public float Damage { get; set; } = 25f;

    public override void Attack(Enemy enemy)
    {
        enemy.TakeDamage(Damage);
    }
}
