using UnityEngine;
using System.Collections;

public class SlowTurret : BaseTurret
{
    public float slowAmount = 0.5f;
    public float slowDuration = 3f;
    public GameObject bulletPrefab;
    public Transform firePoint;


    public override void Shoot()
    {
        {
            if (currentTarget != null)
            {
                GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
                Bullet bullet = bulletGO.GetComponent<Bullet>();
                if (bullet != null)
                {
                    bullet.damage = damage;
                    bullet.SetTarget(currentTarget.transform);
                }
            }
        }
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
