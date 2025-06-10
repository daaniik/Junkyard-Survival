using UnityEngine;

public class BuildSpot : MonoBehaviour
{
    private GameObject turret;

    void OnMouseDown()
    {
        if (turret != null) return;

        var placer = TurretPlacer.instance;
        var manager = CoinManager.instance;

        if (placer.selectedTurret != null && manager.SpendCoins(placer.selectedCost))
        {
            turret = Instantiate(placer.selectedTurret, transform.position, Quaternion.identity);
        }
    }
}
