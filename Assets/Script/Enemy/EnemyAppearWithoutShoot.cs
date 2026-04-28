using UnityEngine;

public class EnemyAppearWithoutShoot : LoadEnemyCtrlAbstract,IObjAppearObserver
{
    [Header("EnemyAppear WithoutShoot")]
    [SerializeField] protected EnemyAppearingBigger enemyAppearingBigger;
    protected EnemyAppearingBigger EnemyAppearingBigger => enemyAppearingBigger;
    protected override void OnEnable()
    {
        this.RegisterAppearEvent();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.enemyAppearingBigger=GetComponent<EnemyAppearingBigger>();
    }
    protected virtual void RegisterAppearEvent()
    {
        this.enemyAppearingBigger.ObserverAdd(this);
    }

    public void OnAppearStart()
    {
        this.enemyController.EnemyShooting.gameObject.SetActive(false);
        this.enemyController.LookatObjShip.gameObject.SetActive(false);
    }

    public void OnAppearFinish()
    {
        this.enemyController.EnemyShooting.gameObject.SetActive(true);
        this.enemyController.LookatObjShip.gameObject.SetActive(true);
    }
}
