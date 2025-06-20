using UnityEngine;
using System.Collections;

public class BurnTurret : BaseTurret
{
    public float burnDamage = 2f;// hoeveel burn damage die krijgt per seconde
    public int burnDuration = 3;// hoe lang het burn effect duurt
    public ParticleSystem flameEffect;// de visuele flame

    public override void Shoot()
    {
        if (currentTarget != null)
        {
            currentTarget.TakeDamage(damage);
            StartCoroutine(Burn(currentTarget));

            if (!flameEffect.isPlaying)
                flameEffect.Play();
        }
        // doet damage zoals de slow turret
        // start de particle system als er een enemy in range is en dr onder als dr geen is stopt die met afspelen 
        else
        {
            if (flameEffect.isPlaying)
                flameEffect.Stop();
        }
    }

    IEnumerator Burn(Enemy enemy)
    {
        for (int i = 0; i < burnDuration; i++)
        {
            if (enemy == null) yield break;
            enemy.TakeDamage(burnDamage);
            yield return new WaitForSeconds(1f);
        }
    }
    // start de coroutine voor de burn damage
    // dit laat het herhaal voor hoelang de burn moet duren 
    // derde ding is als de enemy doodgaat of verwijderd woord stopt die meteen met de coroutine
    // vierde ding dit doet de damage per seconde 
    // laatste ding wacht steeds 1 seconde om weer damage tedoen

}

