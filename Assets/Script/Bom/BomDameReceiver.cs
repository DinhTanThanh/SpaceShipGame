using UnityEngine;
[RequireComponent(typeof(PolygonCollider2D))]
public class BomDameReceiver : DameReceiver
{
    [SerializeField] protected PolygonCollider2D polygonCollider2D;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.Reborn();
        this.LoadPolygonCollider2D();
    }
    protected virtual void LoadPolygonCollider2D()
    {
        if (this.polygonCollider2D != null) return;
        this.polygonCollider2D=GetComponent<PolygonCollider2D>();
        this.polygonCollider2D.isTrigger = true;
        Debug.LogWarning("Load PolygonCollider2D: " + transform.name);
    }
    private void Update()
    {
        if (!this.isDead) return;
        SoundFX.Instance.PlayOneShotSoundBoomExplosion();
        SpawnBom.Instance.GoBackList(this.transform.parent.gameObject);
        Vector3 pos = transform.parent.position;
        this.transform.parent.gameObject.SetActive(false);
        SpawnSmoke.instance.SetPosition(SpawnSmoke.instance.Smoke, pos, Quaternion.identity);
        this.Reborn();
    }
    public override void Reborn()
    {
        this.maxHp = 1;
        this.hp = this.maxHp;
        this.isDead = false;
    }
}
