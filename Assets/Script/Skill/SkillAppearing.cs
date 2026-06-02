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
        //hàm này chưa cải tiến (phương hướng cải tiến sẽ dùng dirty design pattern để load hotkey thay đổi chứ không load hết hotkey như hiện tại)
        foreach (ItemInventory child in this.hotKeyController.Inventory.Items)
        {
            if (child.itemProfileSO.itemType == ItemType.Skill)
            {
                string nameSkill=child.itemProfileSO.itemCode.ToString();
                //Debug.Log(nameSkill);
                nameSkill = nameSkill.Replace("_item","");
                Debug.Log(nameSkill);
                Transform skill = this.managerSkill.transform.Find(nameSkill);
                if (skill == null) continue;
                this.SetParentForSkill(skill);
            }
        }
    }
    protected virtual void SetParentForSkill(Transform skill)
    {
        foreach(Transform child in transform)
        {
            if (child.childCount > 0) continue;
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
