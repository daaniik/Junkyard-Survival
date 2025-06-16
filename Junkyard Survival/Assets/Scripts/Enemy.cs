using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float moveSpeed = 3f;
    public float distanceTraveled = 0f;
    public int coinValue = 10;
    public int damageToBase = 10;

    void Update()
    {
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
        health -= amount;
        if (health <= 0f)
        {
            CoinManager.instance.AddCoins(coinValue);
            Destroy(gameObject);
        }
    }
}
