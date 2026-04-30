using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public abstract class SortOderInLayerAbstract : LoadMonoBehaviour
{
    [SerializeField] protected int orderInObj;
    public int OrderInObj=>orderInObj;
    protected abstract void SetSortOrderObject();
}
