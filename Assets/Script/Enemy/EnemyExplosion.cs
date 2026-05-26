using UnityEngine;
[RequireComponent(typeof(PolygonCollider2D))]
public class EnemyExplosion : LoadMonoBehaviour
{
    [SerializeField] protected PolygonCollider2D poligonCollider;
    [SerializeField] protected EnemyExplosionController enemyExplosionController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPolygonCollider2D();
        this.LoadEnemyExplosionController();
    }
    protected virtual void LoadEnemyExplosionController()
    {
        if (this.enemyExplosionController != null) return;
        this.enemyExplosionController=transform.parent?.parent?.GetComponent<EnemyExplosionController>();
        Debug.LogWarning("Load EnemyExplosionController: " + transform.name);
    }
    protected virtual void LoadPolygonCollider2D()
    {
        if (this.poligonCollider != null) return;
        this.poligonCollider=GetComponent<PolygonCollider2D>();
        Debug.LogWarning("Load PolygonCollider2D: " + transform.name);
    }
    protected virtual void SetAttributeComponent()
    {
        if (this.poligonCollider == null) return;
        this.poligonCollider.isTrigger = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform enemyExplosionPos = collision.transform.parent?.parent?.transform;
        PlayerDameReceiver playerDameReceiver=enemyExplosionPos.GetComponentInChildren<PlayerDameReceiver>();
        if (playerDameReceiver != null)
        {
            playerDameReceiver.Receiver(2);
            SpawnExplosion.Instance.SetPosition(SpawnExplosion.Instance.Explosion, enemyExplosionPos.position, Quaternion.identity);
            if (playerDameReceiver.CheckIsDead())
            {
                playerDameReceiver.IsDead = true;
            }
            GameObject enemyExplosion = transform.parent.parent.gameObject;
            SpawnEnemyExplosion.Instance.GoBackList(enemyExplosion);
            enemyExplosion.SetActive(false);
            this.enemyExplosionController.MoveToPlayer.SetSpeed(0.7f);
        }
    }
}
