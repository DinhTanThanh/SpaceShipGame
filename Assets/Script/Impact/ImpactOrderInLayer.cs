using UnityEngine;

public class ImpactOrderInLayer : BaseSortOderInLayer
{
    protected override void LoadComponent()
    {
        this.SetSortOrder(14);
        base.LoadComponent();
    }
}
