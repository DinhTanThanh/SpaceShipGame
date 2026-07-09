using UnityEngine;
public class Level_1 : BaseLevel
{
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyMotherShipCtrl();
    }
    protected virtual void LoadEnemyMotherShipCtrl()
    {
        if (this.shootingController != null) return;
        this.shootingController = FindFirstObjectByType<EnemyMotherShipCtrl>();
        Debug.LogWarning("Load EnemyMotherShipCtrl: " + transform.name);
    }

    public override ShootingController GetBossLevel()
    {
        throw new System.NotImplementedException();
    }

    public override void RebornLevel()
    {
        this.shootingController.gameObject.SetActive(false);

        EnemyMotherShipCtrl enemyMotherShipController=this.shootingController.GetComponent<EnemyMotherShipCtrl>();
        if (enemyMotherShipController == null) return;
        enemyMotherShipController.AbilitySummonController.AbilitySummonEnemy.ResetNumberEnemy();
        Invoke("EnableObject",0.5f);
    }
    protected virtual void EnableObject()
    {
        this.shootingController.gameObject.SetActive(true);
    }
}
