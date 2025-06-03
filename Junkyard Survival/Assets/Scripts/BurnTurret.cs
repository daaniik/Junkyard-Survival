using UnityEngine;
using System.Collections;

public class BurnTurret : BaseTurret
{
    public float burnDamage = 2f;
    public int burnDuration = 3;
    public ParticleSystem flameEffect;

    public override void Shoot()
    {
        if (currentTarget != null)
        {
            currentTarget.TakeDamage(damage);
            StartCoroutine(Burn(currentTarget));

            if (!flameEffect.isPlaying)
                flameEffect.Play();
        }
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
}
