using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    public static Lose instance;
    public int baseHealth = 10;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void TakeDamage(int amount)
    {
        baseHealth -= amount;
        Debug.Log("Base took damage. Health now: " + baseHealth);

        if (baseHealth <= 0)
        {
            SceneManager.LoadScene("Youlosemenu"); 
        }
    }
}
