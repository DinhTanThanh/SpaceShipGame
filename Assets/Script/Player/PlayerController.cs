using UnityEngine;

public class PlayerController : ShottingController
{
    [SerializeField] protected InputManager inputManager;
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected PlayerCtrl playerCtrl;

    public InputManager InputManager => inputManager;
    public Inventory Inventory => inventory;
    public PlayerCtrl PlayerCtrl => playerCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInventory();
        this.LoadInputManager();
        this.LoadPlayerCtrl();
        LoadEnemySO();
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;
        this.playerCtrl = FindFirstObjectByType<PlayerCtrl>();
        Debug.LogWarning("Load PlayerCtrl: " + transform.name);
    }
    protected virtual void LoadInputManager()
    {
        if (inputManager != null) return;
        this.inputManager = FindFirstObjectByType<InputManager>();
        Debug.LogWarning("Load InputManager: " + transform.name);
    }
    protected virtual void LoadInventory()
    {
        if (inventory != null) return;
        this.inventory = GetComponentInChildren<Inventory>();
        Debug.LogWarning("Load Inventory: " + transform.name);
    }
    public override void LoadEnemySO()
    {
        if (this.shottingSO != null) return;
        string path = "Shotting/Player/" + transform.name;
        this.shottingSO = Resources.Load<ShottingSO>(path);
        Debug.LogWarning("Load EnemySO: " + transform.name);
    }
}
