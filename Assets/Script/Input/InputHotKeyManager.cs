using UnityEngine;

public class InputHotKeyManager : LoadMonoBehaviour
{
    private static InputHotKeyManager instance;
    public static InputHotKeyManager Instance => instance;
    [SerializeField] protected int isPressOne;
    public int IsPressOne => isPressOne;

    [SerializeField] protected HotKeyController hotKeyController;
    public HotKeyController HotKeyController => hotKeyController;
    protected override void Awake()
    {
        InputHotKeyManager.instance = this;
        base.Awake();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHotKeyController();
    }
    private void Update()
    {
        this.GetHotKeyDown();
    }
    protected virtual void LoadHotKeyController()
    {
        if (this.hotKeyController != null) return;
        this.hotKeyController = FindFirstObjectByType<HotKeyController>();
        Debug.LogWarning("Load HotKeyController: " + transform.name);
    }
    protected void GetHotKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) this.Press(1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) this.Press(2);
        if (Input.GetKeyDown(KeyCode.Alpha3)) this.Press(3);
        if (Input.GetKeyDown(KeyCode.Alpha4)) this.Press(4);
        if (Input.GetKeyDown(KeyCode.Alpha5)) this.Press(5);
        if (Input.GetKeyDown(KeyCode.Alpha6)) this.Press(6);
        if (Input.GetKeyDown(KeyCode.Alpha7)) this.Press(7);
    }
    protected void Press(int index)
    {
        this.isPressOne = index;
        if (index == 0) return;
        ItemSlot itemSlot = this.hotKeyController.PressHotKey.ListItemSlot[index - 1];
        if (itemSlot == null) return;
        DrapItem drapItem = itemSlot.GetComponentInChildren<DrapItem>();
        if (drapItem == null) return;
        Debug.Log("Press skill: " + index);

    }
}
