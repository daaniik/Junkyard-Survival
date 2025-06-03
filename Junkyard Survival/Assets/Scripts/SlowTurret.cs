using UnityEngine;
using System.Collections;

public class SlowTurret : BaseTurret
{
    public float slowAmount = 0.5f;
    public float slowDuration = 3f;

    public override void Shoot()
    {
        if (currentTarget != null)
        {
            currentTarget.TakeDamage(damage); // Base damage
            StartCoroutine(Slow(currentTarget));
        }
    }

    IEnumerator Slow(Enemy enemy)
    {
        float originalSpeed = enemy.moveSpeed;
        enemy.moveSpeed *= slowAmount;

        yield return new WaitForSeconds(slowDuration);

        if (enemy != null)
            enemy.moveSpeed = originalSpeed;
    }
}
