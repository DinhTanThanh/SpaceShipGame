using UnityEngine;

public class EnemyAppearWithoutMoving : EnemyExplosionAbstract,IObjAppearObserver
{
    [SerializeField] protected EnemyExplosionAppearing enemyExplosionAppearing;
    public EnemyExplosionAppearing EnemyExplosionAppearing => enemyExplosionAppearing;
    protected override void Awake()
    {
        base.Awake();
        this.enemyExplosionAppearing.AddObjecrAppear(this);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadenEmyExplosionAppearing();
    }
    protected virtual void LoadenEmyExplosionAppearing()
    {
        if (this.enemyExplosionAppearing != null) return;
        this.enemyExplosionAppearing=GetComponent<EnemyExplosionAppearing>();
        Debug.LogWarning("Load EnemyExplosionAppearing: " + transform.name);
    }

    public void OnAppearStart()
    {
        this.enemyExplosionController.MoveToPlayer.gameObject.SetActive(false);
        this.EnemyExplosionController.FollowGateway.gameObject.SetActive(true);
    }

    public void OnAppearFinish()
    {
        this.enemyExplosionController.MoveToPlayer.gameObject.SetActive(true);
        this.EnemyExplosionController.FollowGateway.gameObject.SetActive(false);
    }
}
