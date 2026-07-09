using UnityEngine;
[RequireComponent(typeof(PolygonCollider2D))]
public class BulletLazeDameSender : CountTime
{
    [SerializeField] protected PolygonCollider2D polygonCollider2D;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.SetTimeDelay(0.3f);
        this.LoadPolygonCollider2D();
    }
    protected virtual void LoadPolygonCollider2D()
    {
        if (this.polygonCollider2D != null) return;
        this.polygonCollider2D = GetComponent<PolygonCollider2D>();
        this.polygonCollider2D.isTrigger = true;
        Debug.LogWarning("Load PolygonCollider2D: " + transform.name);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerDameReceiver dameReceiver = collision.transform.parent?.parent?.GetComponentInChildren<PlayerDameReceiver>();
        if (dameReceiver == null)
        {
            Debug.Log("NUll");
            return;
        }
        if (!this.Timing()) return;
        SoundFX.Instance.PlayOneShotSoundElectric();
        SendDame(dameReceiver, 1);
        if (dameReceiver.CheckIsDead())
        {
            dameReceiver.IsDead = true;
        }
    }
}
