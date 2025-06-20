using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    public static Lose instance;// dit zorgt ervoor dat dr maar altijd een versie van de klasse bestaat
    public int baseHealth = 10;// de hp die het eind punt heeft

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    // het eerste stuk controleert of er al een andere versie is van de lose 
    // tweede stukje maakt dit het de enige instantie
    // het laatste verwijderd zichzelf als dr al een lose object bestaat
    

    public void TakeDamage(int amount)
    {
        baseHealth -= amount;
        Debug.Log("Base took damage. Health now: " + baseHealth);

        if (baseHealth <= 0)
        {
            SceneManager.LoadScene("Youlosemenu"); 
        }
    }
    // dit word opgeroepen waarneer het damage krijgt
    // tweede stukje haalt de healt af van de amount dat damage doet 
    // laatste stukje is als de base minder dan 0 hp heeft dan laad die de lose menu
}
