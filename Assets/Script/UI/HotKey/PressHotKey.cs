using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class PressHotKey : LoadMonoBehaviour
{
    [SerializeField] protected HotKeyController hotKeyController;
    public HotKeyController HotKeyController => hotKeyController;
    [SerializeField] protected List<ItemSlot> listItemSlots;
    public List<ItemSlot> ListItemSlot => listItemSlots;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHotKeyController();
        this.GetListItemSlot();
    }
    protected virtual void LoadHotKeyController()
    {
        if (this.hotKeyController != null) return;
        this.hotKeyController=transform.parent.GetComponent<HotKeyController>();
        Debug.LogWarning("Load HotKeyController: " + transform.name);
    }
    protected virtual void GetListItemSlot()
    {
        if (this.hotKeyController == null) return;
        if (this.listItemSlots.Count > 0) return;
        ItemSlot[] itemSlots  =this.hotKeyController.transform.GetComponentsInChildren<ItemSlot>();
        this.listItemSlots.AddRange(itemSlots);
        Debug.LogWarning("Get ListItemSlots:" + transform.name);
    }
    
}
