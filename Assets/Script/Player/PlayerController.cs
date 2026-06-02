using UnityEngine;

public class PlayerController : ShootingController
{
    [SerializeField] protected InputManager inputManager;
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected Shooting shooting;
    [SerializeField] protected AbilityWarpCtrl abilityWarpCtrl;
    public InputManager InputManager => inputManager;
    public Inventory Inventory => inventory;
    public PlayerCtrl PlayerCtrl => playerCtrl;
    public Shooting Shooting => shooting;
    public AbilityWarpCtrl AbilityWarpCtrl => abilityWarpCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInventory();
        this.LoadInputManager();
        this.LoadPlayerCtrl();
        this.LoadShooting();
        this.LoadEnemySO();
        this.LoadAbilityWarpCtrl();
    }
    protected virtual void LoadAbilityWarpCtrl()
    {
        if (this.abilityWarpCtrl != null) return;
        this.abilityWarpCtrl = FindFirstObjectByType<AbilityWarpCtrl>();
        Debug.LogWarning("Load AbilityWarpCtrl: " + transform.name);
    }
    protected virtual void LoadShooting()
    {
        if (this.shooting != null) return;
        this.shooting=GetComponentInChildren<Shooting>();
        Debug.LogWarning("Load Shooting: " + transform.name);
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
        if (this.shootingSO != null) return;
        string path = "Shooting/Player/" + transform.name;
        this.shootingSO = Resources.Load<ShootingSO>(path);
        Debug.LogWarning("Load EnemySO: " + transform.name);
    }
}
