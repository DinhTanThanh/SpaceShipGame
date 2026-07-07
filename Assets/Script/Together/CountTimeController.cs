using UnityEngine;

public class CountTimeController : LoadMonoBehaviour
{
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected PlayerController playerController;
    [SerializeField] protected ShootingController bossLevelCurrent;
    private void Update()
    {
        this.CountTime();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerController();
        this.LoadBossDefault();
    }
    protected virtual void LoadBossDefault()
    {
        if (this.bossLevelCurrent != null) return;
        this.bossLevelCurrent = FindFirstObjectByType<EnemyMotherShipCtrl>();
        Debug.LogWarning("Load BossDefault: " + transform.name);
    }
    protected virtual void LoadPlayerController()
    {
        if (this.playerController != null) return;
        this.playerController = FindFirstObjectByType<PlayerController>();
        Debug.LogWarning("Load PlayerController: " + transform.name);
    }
    public virtual void ResetTimer()
    {
        this.timer = 0f;
    }
    protected virtual void CountTime()
    {
        if (this.playerController.DameReceiver.IsDead) return;
        if (this.bossLevelCurrent.DameReceiver.IsDead) return;
        this.timer += Time.deltaTime;
    }
    public virtual void SetBossCurrent(ShootingController bossCurrent)
    {
        this.bossLevelCurrent = bossCurrent;
    }
    public virtual string ConvertToMinute()
    {
        int minute =(int)this.timer / 60;
        int second = (int)this.timer % 60;
        return minute + ":" + second.ToString("00")+"s";
    }
}
