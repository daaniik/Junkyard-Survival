using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (other.CompareTag("Base"))
        {
            if (Lose.instance != null)
            {
                Lose.instance.TakeDamage(damageToBase);
            }

            Destroy(gameObject);
        }
    }

    public void TakeDamage(float amount)
    {
        if (isDying) return;

        health -= amount;
        if (health <= 0f)
        {
            isDying = true;
            CoinManager.instance.AddCoins(coinValue);
            animator.SetTrigger("Dood"); // Make sure you have a "Die" trigger in Animator
            Destroy(gameObject, 1f); // Delay so animation can play
        }
    }
}