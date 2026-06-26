using UnityEngine;

public class BulletEnemyOrderLayer : BaseSortOderInLayer
{
    protected override void LoadComponent()
    {
        this.SetSortOrder(12);
        base.LoadComponent();
    }
}
