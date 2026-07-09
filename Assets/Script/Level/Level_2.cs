using UnityEngine;

public class Level_2 : BaseLevel
{
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossSpaceController();
    }
    protected virtual void LoadBossSpaceController()
    {
        if (this.shootingController != null) return;
        this.shootingController = GetComponentInChildren<BossSpaceController>();
        Debug.LogWarning("Load BossSpaceController: " + transform.name);
    }
    public override ShootingController GetBossLevel()
    {
        return this.shootingController;
    }

    public override void RebornLevel()
    {
        this.shootingController.gameObject.SetActive(false);
        Invoke("EnableObject", 0.5f);
    }
    protected virtual void EnableObject()
    {
        this.shootingController.gameObject.SetActive(true);
    }
}
