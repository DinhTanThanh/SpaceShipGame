using UnityEngine;

public class MotherShipOrderInLayer : BaseSortOderInLayer
{
    protected override void LoadComponent()
    {
        this.SetSortOrder(10);
        base.LoadComponent();
    }
}
