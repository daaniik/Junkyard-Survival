using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
    public float health = 100f;// hoeveel hp de enemy heeft
    public float moveSpeed = 3f;// hoe  snel de enemy loopt 
    public float distanceTraveled = 0f;// hoeveel meter de enemy heeft afgelegt 
    public int coinValue = 10;// hoeveel coins je krijgt als de enemy dood gaat
    public int damageToBase = 10;// hoeveel damage de enemy doet 

    void Update()
    {
        float move = moveSpeed * Time.deltaTime;// dit berekend hoe snel de enemies gaan met tijd inplaats van frames 
        transform.Translate(Vector3.forward * move);//
        distanceTraveled += move;// telt hoeveel de de enemies hebben afgelegt
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
    // waarom  void OnTriggerEnter(Collider other) want die wordt ge triggert waaneer de objecten elkaar raken
    // de tweede is voor de tag dat die niet iets anders kan damagen en 
    // de derde roept de lose roept de take damage uit het script op van het lose script
    // laatste killed de enemy en verwijdert hem
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            CoinManager.instance.AddCoins(coinValue);
            Destroy(gameObject);
        }
    }
}  // als de healf minder dan nul is dan krijg je de coins en word de enemy gedestroyed 