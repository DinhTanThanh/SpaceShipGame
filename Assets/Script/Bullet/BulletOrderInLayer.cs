using UnityEngine;

public class BulletOrderInLayer : BaseSortOderInLayer
{
    protected override void LoadComponent()
    {
        this.SetSortOrder(13);
        base.LoadComponent();
    }
}
