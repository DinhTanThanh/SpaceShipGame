using UnityEngine;

public class BomOrderInLayer : BaseSortOderInLayer
{
    protected override void LoadComponent()
    {
        this.SetSortOrder(13);
        base.LoadComponent();
    }
}
