using UnityEngine;

public class BaseTurret : MonoBehaviour
{
    public float range = 5f;
    public float damage = 10f;
    public float fireRate = 1f;

    float fireCountdown = 0f;
    protected Enemy currentTarget;

    void Update()
    {
        if (currentTarget == null || Vector3.Distance(transform.position, currentTarget.transform.position) > range)
        {
            FindFurthestEnemy();
        }

        if (currentTarget == null) return;

        fireCountdown -= Time.deltaTime;
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
    }

    void FindFurthestEnemy()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, range);
        float maxDistance = -1f;
        Enemy best = null;

        foreach (var hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy != null && enemy.distanceTraveled > maxDistance)
            {
                maxDistance = enemy.distanceTraveled;
                best = enemy;
            }
        }

        currentTarget = best;
    }

    public virtual void Shoot()
    {
        if (currentTarget != null)
        {
            currentTarget.TakeDamage(damage); //  Damage happens here
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
