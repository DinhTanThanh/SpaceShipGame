using UnityEngine;

public abstract class InventoryAbstract : MonoBehaviour
{
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory=>inventory;
    protected abstract void LoadComponent();
    protected virtual void Awake()
    {
        LoadComponent();
    }
    protected virtual void Reset()
    {
        LoadComponent();
    }
}
