using UnityEngine;
public class PlayerDameReceiver : DameReceiver
{
    [SerializeField] protected PlayerController playerController;
    public PlayerController PlayerController => playerController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerController();
        this.Reborn();
    }
    protected virtual void LoadPlayerController()
    {
        if (this.playerController != null) return;
        this.playerController = FindAnyObjectByType<PlayerController>();
        Debug.LogWarning("Load PlayerController: " + transform.name);
    }
    protected override void LoadComponentEnable()
    {
        base.LoadComponentEnable();
        this.Reborn();
    }
    public override void Reborn()
    {
        this.hp = this.playerController.ShottingSO.maxHP;
        this.maxHp = this.playerController.ShottingSO.maxHP;
        this.IsDead = false;
    }
    private void Update()
    {
        this.OnDead();
    }
    protected virtual void OnDead()
    {
        if (this.IsDead == true)
        {
            //SpawnSmoke.instance.SetPosition(SpawnSmoke.instance.Smoke, transform.position, transform.rotation);
            //transform.parent.gameObject.SetActive(false);
            //this.playerController.gameObject.SetActive(false);
            //SpawnItems.instance.DropItem(MeteoriteCtrller.ShottingSO.dropItems, transform.position, Quaternion.Euler(0, 0, 0));
        }
    }
}
