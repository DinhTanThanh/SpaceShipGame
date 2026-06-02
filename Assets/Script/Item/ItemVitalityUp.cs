using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class ItemVitalityUp : LoadMonoBehaviour
{
    [SerializeField] protected int maxHpIncrease;
    [SerializeField] protected float healPercent;
    [SerializeField] protected Rigidbody2D rigidBody2D;
    [SerializeField] protected PolygonCollider2D polygonCollider2D;
    protected override void Reset()
    {
        base.Reset();
        this.SetMaxHpIncrease(5);
        this.SetHealPercent(0.1f);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigidbody2D();
        this.LoadPolygonCollider2D();
    }
    protected virtual void LoadRigidbody2D()
    {
        if (this.rigidBody2D != null) return;
        this.rigidBody2D = GetComponent<Rigidbody2D>();
        this.rigidBody2D.gravityScale = 0f;
        Debug.LogWarning("Load Rigidbody2D: " + transform.name);
    }
    protected virtual void LoadPolygonCollider2D()
    {
        if (this.polygonCollider2D != null) return;
        this.polygonCollider2D = GetComponent<PolygonCollider2D>();
        this.polygonCollider2D.isTrigger = true;
        Debug.LogWarning("Load PolygonCollider2D: "+transform.name);
    }
    protected virtual void SetMaxHpIncrease(int maxHpIncrease)
    {
        this.maxHpIncrease= maxHpIncrease;
    }
    protected virtual void SetHealPercent(float healPercent)
    {
        this.healPercent = healPercent;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        PlayerDameReceiver playerDameReceiver=collision.transform.parent?.parent?.GetComponentInChildren<PlayerDameReceiver>();
        if (playerDameReceiver == null) return;
        playerDameReceiver.AddMaxHP(this.maxHpIncrease);
        int healAmount = (int)(playerDameReceiver.Hp * this.healPercent);
        playerDameReceiver.SetHealAmount(healAmount);
        playerDameReceiver.SetIsHealHP(true);
        this.transform.parent.gameObject.SetActive(false);
    }
}
