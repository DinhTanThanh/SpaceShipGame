using UnityEngine;

public class BtnInventory : LoadMonoBehaviour
{
    private static BtnInventory instance;
    [SerializeField] protected bool isOpen = false;
    [SerializeField] protected PlayerController playerController;
    public bool IsOpen => isOpen;
    public static BtnInventory Instance => instance;
    public PlayerController PlayerController=> playerController;
    protected override void Awake()
    {
        base.Awake();
        BtnInventory.instance= this;
    }
    protected override void Start()
    {
        base.Start();
        this.gameObject.SetActive(false);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerController();
    }
    protected virtual void LoadPlayerController()
    {
        if (this.playerController != null) return;
        this.playerController=FindFirstObjectByType<PlayerController>();
        Debug.LogWarning("Load PlayerController: " + transform.name);
    }
    public virtual void ActiveInventory()
    {
        bool statusInventory = !this.isOpen;
        this.gameObject.SetActive(statusInventory);
        this.isOpen = statusInventory;
    }
    public virtual void CloseInventory()
    {
        this.gameObject.SetActive(false);
        this.isOpen = false;
    }
   
}

   
