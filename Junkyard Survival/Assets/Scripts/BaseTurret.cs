using UnityEngine;




public class BaseTurret : MonoBehaviour
{
    public float range = 5f;
    public float damage = 10f;
    public float fireRate = 1f;

    float fireCountdown = 0f;

    void Update()
    {
        fireCountdown -= Time.deltaTime;
        if (fireCountdown <= 0f)
        {
            ShootAtEnemies();
            fireCountdown = 1f / fireRate;
        }
    }

    // Make this method virtual so subclasses can override it
    public virtual void ShootAtEnemies()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, range);
        foreach (var hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
