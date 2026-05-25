using UnityEngine;

public abstract class BaseInventory : LoadMonoBehaviour
{
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;
}
