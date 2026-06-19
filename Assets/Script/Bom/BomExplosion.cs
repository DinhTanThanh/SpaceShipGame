using UnityEngine;
[RequireComponent(typeof(PolygonCollider2D))]
public class BomExplosion : LoadMonoBehaviour
{
    [SerializeField] protected PolygonCollider2D polygonCollider2D;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPolygonCollider2D();
    }
    protected virtual void LoadPolygonCollider2D()
    {
        if (this.polygonCollider2D != null) return;
        this.polygonCollider2D = GetComponent<PolygonCollider2D>();
        this.polygonCollider2D.isTrigger = true;
        Debug.LogWarning("Load PolygonCollider2D: " + transform.name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform player = collision.transform.parent?.parent;
        if (player == null) return;
        PlayerDameReceiver dameReceiver=player.GetComponentInChildren<PlayerDameReceiver>();
        if (dameReceiver == null) return;
        dameReceiver.Receive(2);
        SpawnBom.Instance.GoBackList(transform.parent.gameObject);
        this.transform.parent.gameObject.SetActive(false);
        SpawnSmoke.instance.SetPosition(SpawnSmoke.instance.Smoke,this.transform.parent.position, Quaternion.identity);
    }
}
