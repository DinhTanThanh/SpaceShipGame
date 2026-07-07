using UnityEngine;

public class GetHpBarMotherShip :LoadMonoBehaviour
{
    [SerializeField] protected EnemyMotherShipCtrl enemyMotherShipController;
    public EnemyMotherShipCtrl EnemyMotherShipCtrl => enemyMotherShipController;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.GetHpBar();
    }
    protected virtual void GetHpBar()
    {
        Vector3 posMotherEnemy = this.transform.parent.position;
        GameObject hpBarMotherEnemy = SpawnHpBar.Instance.SetPosition(SpawnHpBar.Instance.HpBar, posMotherEnemy, Quaternion.identity);
        HpBar hpBar = hpBarMotherEnemy.GetComponent<HpBar>();
        if (hpBar == null)
        {
            Debug.LogWarning("Null HPbar ");
            return;
        }
        hpBar.transform.localScale = new Vector3(2, 2, 1);
        hpBar.SetShootingController(this.enemyMotherShipController);
        hpBar.FollowTarget.SetTarget(transform.parent);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyMotherShipCtrl();
    }
    protected virtual void LoadEnemyMotherShipCtrl()
    {
        if (this.enemyMotherShipController != null) return;
        this.enemyMotherShipController=GetComponentInParent<EnemyMotherShipCtrl>();
        Debug.LogWarning("Load EnemyMotherShipController: " + transform.name);
    }
}
