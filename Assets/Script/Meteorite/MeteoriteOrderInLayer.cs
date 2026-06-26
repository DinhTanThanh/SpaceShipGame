using UnityEngine;

public class MeteoriteOrderInLayer : BaseSortOderInLayer
{
    protected override void LoadComponent()
    {
        this.SetSortOrder(11);
        base.LoadComponent();
    }
}
