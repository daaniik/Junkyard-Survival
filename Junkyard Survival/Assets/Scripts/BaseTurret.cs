using System.Security.Cryptography;
using UnityEngine;

public class BaseTurret : MonoBehaviour
{
    public float range = 5f;// hoe ver de turret kan schieten
    public float damage = 10f;// hoeveel damage de turret doet 
    public float fireRate = 1f;// hoe snel de turret die schiet

    float fireCountdown = 0f;// dit telt af tussen de schoten zodat die niet te snel schiet 
    protected Enemy currentTarget;// dit houd bij welke enemy de turret aanvalt en gebruikt protected zodat subklassen dit ook kunnen gebruiken
    // waarom protected want dan kunnen alleen subklassen er bij van de turret en geen andere onodige scripts 

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
    //het eerste kijkt of er enemies zijn in de range zijn en vind dan de enemie die het meest heeft gelopen
    // in de tweede is het als die geen enemie kan vinden dan dan doet de turret niks meer in de frame/ return betekt dat die stopt met uitvoeren van de functie
    //in de derde telt die met seconde door delta time de seconde inplaats van frames dit is hoe die wacht tussen elk schot
    // in de vierde zegt ie dat die mag schieten als de countdownt 0 is  daarna zet die hem weer opnieuw op 1 
    void FindFurthestEnemy()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, range);
        float maxDistance = -1f;
        Enemy best = null;

        foreach (var hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();// dit probeert te zien of er een enemy component opzit en het kijkt naar objecten met het enemy script want die zijn dan geldig 
            if (enemy != null && enemy.distanceTraveled > maxDistance)
            {
                maxDistance = enemy.distanceTraveled;
                best = enemy;
            }
        }

        currentTarget = best;
    }
    // het eerste maakt een array met alle coliders er in binnen de spere/range. de sphere heeft als midden de TP= van de turret en de staal in de sphere is de range
    // het tweede houd bij hoeveel de verste enemy heeft getraveld. waarom -1 omdat elke echte afstand groter dan dat is. en best houd bij welke enemy de beste kanidaat is en daar gaat de turret op schieten dan 
    // de derde gaat door alle objecten die geraakt zijn door OverlapSphere
    // het vierde checkt of de enemy geldig is dus dan is het een vijand en het kijkt naar welke enemy het verst heeft gelopen
    // het vijfde maakt die de keuze welke enemie de beste is om aantevallen en de maxDistance word weer geupdate en vergelijkt met de volgende enemies
    // het laatste stukje doet De turret stelt zijn doelwit currentTarget in op de verste geldige vijand binnen bereik. Als er geen vijanden zijn blijft currentTarget  null.

    public virtual void Shoot()
    {
        if (currentTarget != null)
        {
            currentTarget.TakeDamage(damage); //  Damage happens here
        }
    }
    // het gebruikt virtual zodat subklassen dit kan gebruiken
    // het doet damage als er een enemy is want dan is het geen null met de current target 


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    // dit maakt een visuele range waarneer je in de scene zit om te kijken voor de range goed tezetten 
}
