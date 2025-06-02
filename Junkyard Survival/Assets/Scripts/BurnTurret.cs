using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BurnTurret : BaseTurret
{
    public float burnDamage = 2f;
    public int burnDuration = 3;

    public override void ShootAtEnemies()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, range);
        foreach (var hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                ApplyBurn(enemy);
            }
        }
    }

    void ApplyBurn(Enemy enemy)
    {
        StartCoroutine(BurnEffect(enemy));
    }

    IEnumerator BurnEffect(Enemy enemy)
    {
        int timer = 0;
        while (timer < burnDuration)
        {
            if (enemy == null) yield break;
            enemy.TakeDamage(burnDamage);
            timer++;
            yield return new WaitForSeconds(1f);
        }
    }
}
