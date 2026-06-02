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
        playerDameReceive.Receiver(2);
        SpawnSmoke.instance.SetPosition(SpawnSmoke.instance.Smoke, transform.position, transform.rotation);
        transform.parent.gameObject.SetActive(false);
        SpawnMeteorite.instance.GoBackList(transform.parent.gameObject);
        SpawnItems.instance.DropItem(MeteoriteController.ShootingSO.dropItems, transform.position, Quaternion.Euler(0, 0, 0));
    }
}
