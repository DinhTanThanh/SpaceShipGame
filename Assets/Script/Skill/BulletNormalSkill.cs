using UnityEngine;

public class BulletNormalSkill : BaseSkill
{
    [SerializeField] protected GameObject bulletCurrent;
    [SerializeField] protected PlayerController playerController;
    public PlayerController PlayerController => playerController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerController();
        this.LoadBulletCurrent();
    }
    protected virtual void LoadBulletCurrent()
    {
        if (this.bulletCurrent != null) return;
        this.bulletCurrent = GameObject.Find("ManagerBullet")?.transform.Find("Bullet")?.gameObject;
        Debug.LogWarning("Load Bullet: " + transform.name);
    }
    protected virtual void LoadPlayerController()
    {
        if (this.playerController != null) return;
        this.playerController = FindFirstObjectByType<PlayerController>();
        Debug.LogWarning("Load PlayerController: " + transform.name);
    }
    public override void ActiveSkill()
    {
        this.playerController.Shooting.SetBulletCurrent(this.bulletCurrent);
    }
}
