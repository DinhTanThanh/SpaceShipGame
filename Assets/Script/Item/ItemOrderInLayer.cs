using UnityEngine;

public class ItemOrderInLayer : BaseSortOderInLayer
{
    protected override void LoadComponent()
    {
        this.SetSortOrder(13);
        base.LoadComponent();
    }
}
