using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret
{
    public float Range { get; set; }
    public float FireRate { get; set; }

    public abstract void Attack(Enemy enemy);
}
