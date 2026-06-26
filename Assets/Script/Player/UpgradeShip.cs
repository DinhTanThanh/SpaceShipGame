using UnityEngine;

public class UpgradeShip : LoadMonoBehaviour,IObjChangeItemObserver
{
    [SerializeField] protected AbilityWarpCtrl abilityWarpCtrl;
    public AbilityWarpCtrl AbilityWarpCtrl => abilityWarpCtrl;
    protected override void Start()
    {
        base.Start();
        this.abilityWarpCtrl.PlayerController.Inventory.AddItemChange(this);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAbilityWarpCtrl();
    }
    protected virtual void LoadAbilityWarpCtrl()
    {
        if (this.abilityWarpCtrl != null) return;
        this.abilityWarpCtrl=GetComponentInParent<AbilityWarpCtrl>();
        Debug.LogWarning("Load AbilityWarpCtrl: " + transform.name);
    }

    public void OnChangeItem()
    {
        foreach(ItemInventory itemInventory in this.abilityWarpCtrl.PlayerController.Inventory.Items)
        {
            Debug.Log("Duyet");
            if(itemInventory.itemProfileSO.itemCode.ToString()== "ShipBlue")
            {
                this.abilityWarpCtrl.PlayerController.SpriteRenderer.sprite = itemInventory.itemProfileSO.sprite;
                this.abilityWarpCtrl.PlayerController.Shooting.SetTimeDelay(0.08f);
                return;
            }
        }
    }
}
