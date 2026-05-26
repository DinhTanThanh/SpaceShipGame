using UnityEngine;

public class ExplosionOrderInPlayer : SortOderInLayerAbstract
{
    [SerializeField] protected SpriteRenderer spriteRenderer;
    protected override void SetSortOrderObject()
    {
        this.orderInObj = 12;
        this.spriteRenderer.sortingOrder = this.orderInObj;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpriteRenderer();
        this.SetSortOrderObject();
    }
    protected virtual void LoadSpriteRenderer()
    {
        if (this.spriteRenderer != null) return;
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.LogWarning("Load SpriteRenderer: " + transform.name);
    }
}
