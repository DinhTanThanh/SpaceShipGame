using UnityEngine;

public class PlayerOrderInLayer : BaseSortOderInLayer
{
    protected override void LoadComponent()
    {
        this.SetSortOrder(13);
        base.LoadComponent();
    }
}
