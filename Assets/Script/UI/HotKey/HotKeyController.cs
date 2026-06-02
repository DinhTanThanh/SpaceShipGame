using UnityEngine;

public class HotKeyController : LoadMonoBehaviour
{
    private static HotKeyController instance;
    public static HotKeyController Instance => instance;
    [SerializeField] protected PressHotKey pressHotKey;
    public PressHotKey PressHotKey => pressHotKey;
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;
    protected override void Awake()
    {
        if (HotKeyController.instance != null) Debug.LogError("Only one singleton is allowed to exist");
        HotKeyController.instance= this;
        base.Awake();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPressHotKey();
        this.LoadInventory();
    }
    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = FindFirstObjectByType<Inventory>();
        Debug.LogWarning("Load Inventory: " + transform.name);
    }
    protected virtual void LoadPressHotKey()
    {
        if (this.pressHotKey != null) return;
        this.pressHotKey=transform.GetComponentInChildren<PressHotKey>();
        Debug.LogWarning("Load PressHotKey: " + transform.name);
    }
}
