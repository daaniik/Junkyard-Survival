using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float moveSpeed = 3f;
    public float distanceTraveled = 0f;
    public int coinValue = 10;
    public int damageToBase = 10;

    private bool isDying = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDying)
        {
            float move = moveSpeed * Time.deltaTime;
            transform.Translate(Vector3.forward * move);
            distanceTraveled += move;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Base") && !isDying)
        {
            if (Lose.instance != null)
            {
                Lose.instance.TakeDamage(damageToBase);
            }

            StartCoroutine(DieAndDestroy());
        }
    }

    public void TakeDamage(float amount)
    {
        if (isDying) return;

        health -= amount;
        if (health <= 0f)
        {
            CoinManager.instance.AddCoins(coinValue);
            StartCoroutine(DieAndDestroy());
        }
    }

    private IEnumerator DieAndDestroy()
    {
        isDying = true;

        if (animator != null)
        {
            animator.SetTrigger("Dood");
            yield return new WaitForSeconds(2.5f); // Pas aan op basis van je animatieduur
        }

        Destroy(gameObject);
    }
}
