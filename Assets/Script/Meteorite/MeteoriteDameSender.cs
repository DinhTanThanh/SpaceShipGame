using UnityEngine;

public class MeteoriteDameSender : DameSender
{
    [SerializeField] protected MeteoriteController meteoriteController;
    public MeteoriteController MeteoriteController => meteoriteController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMeteoriteController();
    }
    protected virtual void LoadMeteoriteController()
    {
        if (this.meteoriteController != null) return;
        this.meteoriteController=GetComponentInParent<MeteoriteController>();
        Debug.LogWarning("Load MeteoriteController: " + transform.name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerDameReceiver playerDameReceive=collision.transform.parent?.parent?.GetComponentInChildren<PlayerDameReceiver>();
        if (playerDameReceive == null) return;
        SendDame(playerDameReceive, 2);
        this.meteoriteController.DameReceiver.IsDead = true;
    }
}
