using UnityEngine;

public class AsteroidOrderInLayer : BaseSortOderInLayer
{
    protected override void LoadComponent()
    {
        this.SetSortOrder(0);
        base.LoadComponent();
    }
}
