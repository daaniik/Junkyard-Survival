using UnityEngine;
using System.Collections;

public class SlowTurret : BaseTurret
{
    public float slowAmount = 0.5f;// hoe veel die de enemy vertraagt
    public float slowDuration = 3f;// voor hoelang die de enemy vertraagt
    public GameObject bulletPrefab;// de kogel van de turrets
    public Transform firePoint;// het punt waar de kogels uitkomen 


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
    // de override doet die omdat dit zn eigen versie is van het schieten en niet die van de base turret
    //tweede stukje zegt dat die een kogel moet aan maken en met dat moeilijke woord beteknt dat er geen rotatie is
    // derde haalt het bullet script op die op de kogel zit 
    //vierde stukje zet de damage gelijk aan de turret en geeft de juiste enemy aan en zorgt dat die er naar toe vliegt
    // het laatste stukje doet de damage en daarna start die de code coroutine voor de slow

    IEnumerator Slow(Enemy enemy)
    {
        float originalSpeed = enemy.moveSpeed;
        enemy.moveSpeed *= slowAmount;

        yield return new WaitForSeconds(slowDuration);

        if (enemy != null)
            enemy.moveSpeed = originalSpeed;
    }
    // een coroutine geeft tijdelijke effect
    // tweede stukje slaat die de originele snelheid op van de enemy zodat die em weer terug kan zetten
    //Vertraag de vijand.Bijvoorbeeld: moveSpeed = 3 slowAmount = 0.5  nieuwe snelheid = 1.5


}
