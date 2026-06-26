using UnityEngine;

public class ExplosionOrderInPlayer : BaseSortOderInLayer
{
    protected override void LoadComponent()
    {
        this.SetSortOrder(12);
        base.LoadComponent();
    }
}
