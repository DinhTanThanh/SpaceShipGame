using UnityEngine;

public class EnemyController : ShottingController
{
    public override void LoadMeteoriteSO()
    {
        if (ShottingSO != null) return;
        string nameMeteoriteSO = "Shotting/Enemy/" + transform.name;
        shottingSO = Resources.Load<ShottingSO>(nameMeteoriteSO);
    }
}
