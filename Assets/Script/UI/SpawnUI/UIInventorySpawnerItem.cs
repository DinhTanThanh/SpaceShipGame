using UnityEngine;

public class UIInventorySpawnerItem : PoolPrefab
{
    private static UIInventorySpawnerItem instance;
    public static UIInventorySpawnerItem Instance => instance;
    [SerializeField] protected GameObject prefab;
    [SerializeField] protected GameObject uiInventory;
    public GameObject Prefab => prefab;

    public GameObject UiInventory => uiInventory;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefab();
        this.LoadUiInventory();
    }
    protected override void Awake()
    {
        base.Awake();
        UIInventorySpawnerItem.instance = this;
    }
    protected virtual void LoadPrefab()
    {
        if (this.prefab != null) return;
        this.prefab = transform.Find("Prefab").GetChild(0).gameObject;
        Debug.LogWarning("Load Prefab: " + transform.name);
    }

    protected virtual void LoadUiInventory()
    {
        if (this.uiInventory != null) return;
        this.uiInventory = transform.parent.parent.gameObject;
        Debug.LogWarning("Load uiInventory: " + transform.name);
    }
}
