using UnityEngine;

public class SlowBullet : MonoBehaviour
{
    public float damage = 10f;
    public float slowAmount = 0.5f;
    public float slowDuration = 3f;
    public float speed = 10f;
    private Transform target;

    public void SetTarget(Transform t)
    {
        target = t;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            StartCoroutine(ApplySlow(enemy));
            Destroy(gameObject);
        }
    }

    System.Collections.IEnumerator ApplySlow(Enemy enemy)
    {
        float originalSpeed = enemy.moveSpeed;
        enemy.moveSpeed *= slowAmount;

        yield return new WaitForSeconds(slowDuration);

        if (enemy != null)
        {
            enemy.moveSpeed = originalSpeed;
        }
    }
}
