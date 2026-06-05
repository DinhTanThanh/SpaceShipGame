using UnityEngine;

public class BulletRegisterObserver : LoadMonoBehaviour, IObjChangeItemObserver
{
    [SerializeField] protected PlayerController playerController;
    protected override void Start()
    {
        this.playerController.Inventory.AddItemChange(this);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadLayerController();
    }
    protected virtual void LoadLayerController()
    {
        if (this.playerController != null) return;
        this.playerController = FindFirstObjectByType<PlayerController>();
        Debug.LogWarning("Load PlayerController: " + transform.name);
    }
    public void OnChangeItem()
    {
        foreach (ItemInventory itemInventory in this.playerController.Inventory.Items)
        {
            if (itemInventory.itemProfileSO.itemType != ItemType.Skill) continue;
            if (!itemInventory.isDirtySkill) continue;
            if (itemInventory.itemProfileSO.itemCode.ToString().Contains("Bullet"))
            {
                this.playerController.Shooting.SetEnableStatusGateWay();
            }
        }
    }
}
