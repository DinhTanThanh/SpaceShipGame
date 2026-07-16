using UnityEngine;

public class PlayerController : ShootingController
{
    [SerializeField] protected InputManager inputManager;
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected Shooting shooting;
    [SerializeField] protected AbilityWarpCtrl abilityWarpCtrl;
    [SerializeField] protected PlayerGatewaysController playerGatewaysController;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected ObjMoveForwardLimitMouse objMoveForwardLimitMouse;
    [SerializeField] protected PlayerPushBack playerPushBack;
    [SerializeField] protected ChipiNoticeController chipiNoticeController;
    public InputManager InputManager => inputManager;
    public Inventory Inventory => inventory;
    public PlayerCtrl PlayerCtrl => playerCtrl;
    public Shooting Shooting => shooting;
    public AbilityWarpCtrl AbilityWarpCtrl => abilityWarpCtrl;
    public PlayerGatewaysController PlayerGatewaysController => playerGatewaysController;
    public SpriteRenderer SpriteRenderer => spriteRenderer;
    public ObjMoveForwardLimitMouse ObjMoveForwardLimitMouse => objMoveForwardLimitMouse;
    public PlayerPushBack PlayerPushBack => playerPushBack;
    public ChipiNoticeController ChipiNoticeController => chipiNoticeController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInventory();
        this.LoadInputManager();
        this.LoadPlayerCtrl();
        this.LoadShooting();
        this.LoadEnemySO();
        this.LoadAbilityWarpCtrl();
        this.LoadPlayerGatewaysController();
        this.LoadSpriteRenderer();
        this.LoadObjMoveForwardLimitMouse();
        this.LoadPlayerPushBack();
        this.LoadChipiNoticeController();
    }
    protected virtual void LoadChipiNoticeController()
    {
        if (this.chipiNoticeController != null) return;
        this.chipiNoticeController = FindFirstObjectByType<ChipiNoticeController>();
        Debug.LogWarning("Load ChipiNoticeController: " + transform.name);
    }
    protected virtual void LoadPlayerPushBack()
    {
        if (this.playerPushBack != null) return;
        this.playerPushBack = GetComponentInChildren<PlayerPushBack>();
        Debug.LogWarning("Load PlayerPushBack: " + transform.name);
    }
    protected virtual void LoadObjMoveForwardLimitMouse()
    {
        if (this.objMoveForwardLimitMouse != null) return;
        this.objMoveForwardLimitMouse = GetComponentInChildren<ObjMoveForwardLimitMouse>();
        Debug.LogWarning("Load ObjMoveForwardLimitMouse: " + transform.name);
    }
    protected virtual void LoadSpriteRenderer()
    {
        if (this.spriteRenderer != null) return;
        this.spriteRenderer=GetComponentInChildren<SpriteRenderer>();
        Debug.LogWarning("Load SpriteRenderer: " + transform.name);
    }
    protected virtual void LoadPlayerGatewaysController()
    {
        if (this.playerGatewaysController != null) return;
        this.playerGatewaysController=GetComponentInChildren<PlayerGatewaysController>();
        Debug.LogWarning("Load PlayerGatewaysController: " + transform.name);
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
    public virtual void DisableShoot()
    {
        this.shooting.gameObject.SetActive(false);
    }
    public virtual void DisableAction()
    {
        this.shooting.gameObject.SetActive(false);
        this.objMoveForwardLimitMouse.gameObject.SetActive(false);
    }
    public virtual void ActiveAction()
    {
        this.shooting.gameObject.SetActive(true);
        this.objMoveForwardLimitMouse.gameObject.SetActive(true);
    }
}
