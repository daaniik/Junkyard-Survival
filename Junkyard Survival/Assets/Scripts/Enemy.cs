using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float moveSpeed = 3f;
    public float distanceTraveled = 0f;
    public int coinValue = 10;
    public int damageToBase = 10;

    private Animator animator;
    private bool isDying = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDying) return;

        float move = moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * move);
        distanceTraveled += move;
    }

    void OnTriggerEnter(Collider other)
    {
        if (isDying) return;

        if (other.CompareTag("Base"))
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

    private System.Collections.IEnumerator DieAndDestroy()
    {
        isDying = true;

        // Stop movement
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }

        // Play death animation
        if (animator != null)
        {
            animator.SetTrigger("Die");
            yield return new WaitForSeconds(1.5f); // Wait for animation to finish
        }

        Destroy(gameObject);
    }
}
