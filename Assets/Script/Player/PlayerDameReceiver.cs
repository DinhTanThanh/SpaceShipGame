using UnityEngine;
public class PlayerDameReceiver : DameReceiver
{
    [Header("Player DameReceiver")]
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeDelay = 0.3f;
    [SerializeField] protected bool isHealHp = false;
    [SerializeField] protected int healAmount;
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
    public virtual void SetHealAmount(int healAmount)
    {
        this.healAmount = healAmount;
    }
    public virtual void SetIsHealHP(bool isHealHP)
    {
        this.isHealHp = isHealHP;
    }
    public override void Reborn()
    {
        this.hp = this.playerController.ShootingSO.maxHP;
        this.maxHp = this.playerController.ShootingSO.maxHP;
        this.IsDead = false;
    }
    protected virtual bool Timing()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.timeDelay) return false;
        this.timer = 0f;
        return true;
    }
    protected virtual void HealHP()
    {
        if (!this.isHealHp) return;
        if (!this.Timing()) return;
        if (this.healAmount <= 0)
        {
            this.isHealHp = false;
            return;
        }
        int newHp = this.hp + 1;
        this.healAmount -= 1;
        if (newHp > this.maxHp) return;
        this.hp= newHp;
    }
    private void Update()
    {
        this.OnDead();
        this.HealHP();
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
