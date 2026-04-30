using UnityEngine;

public class MeteoriteOrderInLayer : SortOderInLayerAbstract
{
    [SerializeField] protected SpriteRenderer spriteRenderer;
    public SpriteRenderer SpriteRenderer => spriteRenderer;
    protected override void LoadComponent()
    {
        this.orderInObj = 11;
        this.spriteRenderer=GetComponent<SpriteRenderer>();
        this.SetSortOrderObject();
    }
    protected override void SetSortOrderObject()
    {
        this.spriteRenderer.sortingOrder = this.orderInObj;
    }
}
