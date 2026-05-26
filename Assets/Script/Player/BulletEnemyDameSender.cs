using UnityEngine;
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletEnemyDameSender : LoadMonoBehaviour
{
    [SerializeField] protected Rigidbody2D rigitbody2d;
    public Rigidbody2D Rigidbody2D => rigitbody2d;
    [SerializeField] protected PolygonCollider2D polygonCollider2D;
    public PolygonCollider2D PolygonCollider2D => polygonCollider2D;
    [SerializeField] protected GameObject managerImpact;
    public GameObject ManagerImpact => managerImpact;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigidbody2D();
        this.LoadPolygonCollider2D();
        this.LoadManagerImpact();
        this.SetAttribute();
    }
    protected virtual void LoadRigidbody2D()
    {
        if (this.rigitbody2d != null) return;
        this.rigitbody2d = FindFirstObjectByType<Rigidbody2D>();
        Debug.LogWarning("Load Rigidbody2D: " + transform.name);
    }
    protected virtual void LoadPolygonCollider2D()
    {
        if (this.polygonCollider2D != null) return;
        this.polygonCollider2D = FindFirstObjectByType<PolygonCollider2D>();
        Debug.LogWarning("Load PolygonCollider2D: " + transform.name);
    }
    protected virtual void LoadManagerImpact()
    {
        if (this.managerImpact != null) return;
        this.managerImpact = GameObject.Find("ManagerImpact");
        //Debug.LogWarning("Load ManagerImpact: " + transform.name);
    }
    protected virtual void SetAttribute()
    {
        this.rigitbody2d.gravityScale = 0;
        this.polygonCollider2D.isTrigger=true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerDameReceiver playerDameReceiver=collision.transform.parent?.parent?.GetComponentInChildren<PlayerDameReceiver>();
        if ((playerDameReceiver!=null))
        {
            playerDameReceiver.Receiver(1);
            Vector3 newPos = transform.position;
            newPos.z = -5f;
            
            GameObject Impact= SpawnImpact.instance.SetPosition(SpawnImpact.instance.Impact, newPos, transform.rotation);
            Impact.transform.SetParent(this.managerImpact.transform);
            if (playerDameReceiver.CheckIsDead())
            {
                playerDameReceiver.IsDead = true;
            }
            SpawnBulletEnemy.instance.GoBackList(transform.parent.gameObject);
            transform.parent.gameObject.SetActive(false);
        }
        
    }
}
