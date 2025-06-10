using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public int coins = 100;
    public TMP_Text coinText;

    void Awake() { instance = this; }
    void Start() { UpdateUI(); }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateUI();
    }

    public bool SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            UpdateUI();
            return true;
        }
        return false;
    }

    void UpdateUI()
    {
        coinText.text = "Coins: " + coins;
    }
}
