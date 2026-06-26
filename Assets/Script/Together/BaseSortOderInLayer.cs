using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public abstract class BaseSortOderInLayer : LoadMonoBehaviour
{
    [SerializeField] protected int orderInObj;
    [SerializeField] SpriteRenderer spriteRenderer;
    public int OrderInObj => orderInObj;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpriteRenderer();
        this.SetSortOrderObject();
    }
    protected virtual void SetSortOrderObject()
    {
        if (this.spriteRenderer == null) return;
        this.spriteRenderer.sortingOrder = this.orderInObj;
    }
    protected virtual void LoadSpriteRenderer()
    {
        if (this.spriteRenderer != null) return;
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.LogWarning("Load SpriteRenderer: " + transform.name);
    }
    protected virtual void SetSortOrder(int orderInObj)
    {
        this.orderInObj=orderInObj;
    }
}
