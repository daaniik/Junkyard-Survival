using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;// hoe snel die vliegt 
    public float damage = 10f;// hoeveel damage die doet
    private Transform target;// hier slaat die mee  op welke enemy die op af gaat

    public void SetTarget(Transform enemyTarget)
    {
        target = enemyTarget;
    }
    // dit word aangeroepen wnr de kogel spawned en het slaat de enemy op als target 
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
    // als target null is dan is de enemy dood dan word de bullet kapot gemaakt
    void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    // het eerste checkt of er een enemy component op zit
    // het tweede is als die dr op zit doet die damage met TakeDamage(damage
    // als die em dan heeft gedamaged gaat de bullet kapot
}
