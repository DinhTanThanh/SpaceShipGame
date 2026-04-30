using UnityEngine;

public class BulletEnemyOrderLayer : SortOderInLayerAbstract
{
    [SerializeField] protected SpriteRenderer spriteRenderer;
    public SpriteRenderer SpriteRenderer => spriteRenderer;
    protected override void LoadComponent()
    {
        this.orderInObj = 12;
        this.spriteRenderer=GetComponent<SpriteRenderer>();
        this.SetSortOrderObject();
    }
    protected override void SetSortOrderObject()
    {
        this.spriteRenderer.sortingOrder = this.orderInObj;
    }
}
