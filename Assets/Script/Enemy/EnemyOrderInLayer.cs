using UnityEngine;

public class EnemyOrderInLayer : BaseSortOderInLayer
{
    protected override void LoadComponent()
    {
        this.SetSortOrder(12);
        base.LoadComponent();
    }
}
