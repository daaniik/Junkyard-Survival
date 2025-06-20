using UnityEngine;

public class TurretPlacer : MonoBehaviour
{
    public static TurretPlacer instance;

    [HideInInspector] public GameObject selectedTurret;
    [HideInInspector] public int selectedCost;

    void Awake() { instance = this; }

    public void SelectTurret(GameObject turretPrefab, int cost)
    {
        selectedTurret = turretPrefab;
        selectedCost = cost;
    }

    public void SelectSlowTurret()
    {
        SelectTurret(slowTurretPrefab, 50);
    }

    public void SelectBurnTurret()
    {
        SelectTurret(burnTurretPrefab, 200);
    }

    public void SelectBubbleTurret()
    {
        SelectTurret(bubbleTurretPrefab, 150);
    }

    public void directDamageTurret()
    {
        SelectTurret(directDamagePrefab, 100);
    }
   
    public GameObject slowTurretPrefab;
    public GameObject burnTurretPrefab;
    public GameObject bubbleTurretPrefab;
    public GameObject directDamagePrefab;
}
