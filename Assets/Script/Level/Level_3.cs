using UnityEngine;

public class Level_3 : BaseLevel
{
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossFinalController();
    }
    protected virtual void LoadBossFinalController()
    {
        if (this.shootingController != null) return;
        this.shootingController = GetComponentInChildren<BossFinalController>();
        Debug.LogWarning("Load BossFinalController: " + transform.name);
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
