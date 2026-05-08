using UnityEngine;

public class ItemOrderInLayer : SortOderInLayerAbstract
{
    [SerializeField] protected SpriteRenderer spriteRenderer;
    public SpriteRenderer SpriteRenderer => spriteRenderer;
    protected override void LoadComponent()
    {
        this.orderInObj = 13;
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.SetSortOrderObject();
    }
    protected override void SetSortOrderObject()
    {
        this.spriteRenderer.sortingOrder = this.orderInObj;
    }
}
