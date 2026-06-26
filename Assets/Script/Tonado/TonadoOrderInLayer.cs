using UnityEngine;

public class TonadoOrderInLayer : BaseSortOderInLayer
{
    protected override void LoadComponent()
    {
        this.SetSortOrder(11);
        base.LoadComponent();
    }
}
