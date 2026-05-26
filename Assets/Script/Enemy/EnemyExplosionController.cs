using UnityEngine;

public class EnemyExplosionController : LoadMonoBehaviour
{
    [SerializeField] protected EnemyMotherShipCtrl enemyMotherShipCtrl;
    public EnemyMotherShipCtrl EnemyMotherShipCtrl => enemyMotherShipCtrl;
    [SerializeField] protected MoveToPlayer moveToPlayer;
    public MoveToPlayer MoveToPlayer => moveToPlayer;
    [SerializeField] protected FollowGateway followGateway;
    public FollowGateway FollowGateway => followGateway;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMoveToPlayer();
        this.LoadenemyMotherShipCtrl();
        this.LoadFollowGateway();
    }
    protected virtual void LoadFollowGateway()
    {
        if (this.followGateway != null) return;
        this.followGateway=GetComponentInChildren<FollowGateway>();
        Debug.LogWarning("Load FollowGateway: " + transform.name);
    }
    protected virtual void LoadMoveToPlayer()
    {
        if (this.moveToPlayer != null) return;
        this.moveToPlayer = GetComponentInChildren<MoveToPlayer>();
        Debug.LogWarning("Load MoveToPlayer: " + transform.name);
    }
    protected virtual void LoadenemyMotherShipCtrl()
    {
        if (this.enemyMotherShipCtrl != null) return;
        this.enemyMotherShipCtrl=FindFirstObjectByType<EnemyMotherShipCtrl>();
        Debug.LogWarning("Load EnemyMotherShipCtrl: " + transform.name);
    }
}
