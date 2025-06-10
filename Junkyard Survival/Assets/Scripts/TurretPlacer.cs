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

    //  These are wrapper methods you can call from UI
    public void SelectSlowTurret()
    {
        SelectTurret(slowTurretPrefab, 50);
    }

    public void SelectBurnTurret()
    {
        SelectTurret(burnTurretPrefab, 75);
    }

    public void SelectBubbleTurret()
    {
        SelectTurret(bubbleTurretPrefab, 100);
    }

    public void directDamageTurret()
    {
        SelectTurret(directDamagePrefab, 100);
    }
    // Assign these in Inspector
    public GameObject slowTurretPrefab;
    public GameObject burnTurretPrefab;
    public GameObject bubbleTurretPrefab;
    public GameObject directDamagePrefab;
}
