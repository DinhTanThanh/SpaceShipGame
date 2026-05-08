using UnityEngine;

public class BtnInventory : LoadMonoBehaviour
{
    private static BtnInventory instance;
    public static BtnInventory Instance => instance;
    [SerializeField] protected bool isOpen=false;
    public bool IsOpen => IsOpen;
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

   
