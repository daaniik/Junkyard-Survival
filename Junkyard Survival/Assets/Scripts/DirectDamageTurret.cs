using UnityEngine;

public class DirectDamageTurret : BaseTurret
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public override void Shoot()
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
}
