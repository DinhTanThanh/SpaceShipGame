using UnityEditor.Build.Content;
using UnityEngine;

public class EnergyShieldYellowEnableByEnemy : LoadMonoBehaviour
{
    [SerializeField] protected int numberLimitEnemy = 0;
    [SerializeField] protected EnergyShieldYellowController energyShieldYellowController;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.transform.parent.gameObject.SetActive(true);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnergyShieldYellowController();
        this.GetNumberLimitEnemy();
    }
    private void Update()
    {
        if (!this.CheckListEnemy()) return;
        this.transform.parent.gameObject.SetActive(false);
    }
    protected virtual void LoadEnergyShieldYellowController()
    {
        if (this.energyShieldYellowController != null) return;
        this.energyShieldYellowController = GetComponentInParent<EnergyShieldYellowController>();
        Debug.LogWarning("Load EnergyShieldYellowController: " + transform.name);
    }
    protected virtual void GetNumberLimitEnemy()
    {
        if (this.numberLimitEnemy != 0) return;
        this.numberLimitEnemy = this.energyShieldYellowController.AbilitySummonController.AbilitySummonEnemy.CountLimitEnemy;
        Debug.LogWarning("Get LimitEnemy: " + transform.name);
    }
    protected virtual bool isFullEnemy()
    {
        return this.energyShieldYellowController.AbilitySummonController.AbilitySummonEnemy.GetCountEnemyInList() == this.numberLimitEnemy;
    }
    protected virtual bool CheckListEnemy()
    {
        if(!this.isFullEnemy()) return false;
        foreach(GameObject enemy in this.energyShieldYellowController.AbilitySummonController.AbilitySummonEnemy.GetListEnemy())
        {
            if (enemy.activeSelf) return false; 
        }
        return true;
    }
}
