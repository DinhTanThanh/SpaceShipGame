using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillAppearing : LoadMonoBehaviour,IObjChangeItemObserver
{
    [SerializeField] protected HotKeyController hotKeyController;
    public HotKeyController HotKetController => hotKeyController;
    [SerializeField] protected Transform managerSkill;
    public Transform ManagerSkill => managerSkill;
    protected override void Start()
    {
        base.Start();
        this.hotKeyController.Inventory.AddItemChange(this);
    }
    public void OnChangeItem()
    {
        foreach (ItemInventory child in this.hotKeyController.Inventory.Items)
        {
            if (child.itemProfileSO.itemType == ItemType.Skill)
            {
                if (!child.isDirtySkill) continue;
                string nameSkill=child.itemProfileSO.itemCode.ToString();
                nameSkill = nameSkill.Replace("_item","");
                Debug.Log(nameSkill);
                Transform skill = this.managerSkill.transform.Find(nameSkill);
                if (skill == null) continue;
                this.SetParentForSkill(skill);
                child.isDirtySkill = false;
            }
        }
    }
    protected virtual void SetParentForSkill(Transform skill)
    {
        List<Transform> listItemSlot=new List<Transform>();
        foreach(Transform child in transform)
        {
            listItemSlot.Add(child);
        }
        listItemSlot.Sort((a,b)=>string.Compare(b.name,a.name,StringComparison.OrdinalIgnoreCase));
        foreach(Transform child in listItemSlot)
        {
            if (child.childCount > 0) continue;
            Debug.Log(child.name);
            skill.SetParent(child);
        }
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHotKeyController();
        this.LoadManagerSkill();
    }
    protected virtual void LoadManagerSkill()
    {
        if (this.managerSkill != null) return;
        this.managerSkill = GameObject.Find("ManagerSkill")?.transform;
        Debug.LogWarning("Load ManagerSkill: " + transform.name);
    }
    protected virtual void LoadHotKeyController()
    {
        if (this.hotKeyController != null) return;
        this.hotKeyController=GetComponentInParent<HotKeyController>();
        Debug.LogWarning("Load HotKeyController: " + transform.name);
    }
}
