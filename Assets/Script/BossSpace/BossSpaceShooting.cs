using System.Collections.Generic;
using UnityEngine;

public class BossSpaceShooting : LoadMonoBehaviour
{
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeDelay = 15f;
    [SerializeField] protected BossSpaceController bossSpaceController;
    public BossSpaceController BossSpaceController => bossSpaceController;
    private void Update()
    {
        this.BossSpaceShoot();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossSpaceController();
    }
    protected virtual void LoadBossSpaceController()
    {
        if (this.bossSpaceController != null) return;
        this.bossSpaceController = GetComponentInParent<BossSpaceController>();
        Debug.LogWarning("Load BossSpaceController: " + transform.name);
    }
    protected virtual void SetDelayTime(float timeDelay)
    {
        this.timeDelay = timeDelay;
    }
    protected virtual bool Timing()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.timeDelay) return false;
        this.timer = 0f;
        return true;
    }
    protected virtual void BossSpaceShoot()
    {
        if (!this.Timing()) return;
        SoundFX.Instance.PlayOneShotSoundShootLaze();
        foreach (Transform gateway in this.bossSpaceController.BossSpaceGateWayController.ListGateway)
        {
            Vector3 pos = gateway.transform.position;
            GameObject bulletLaze=SpawnBulletLaze.Instance.SetPosition(SpawnBulletLaze.Instance.BulletLaze,pos, gateway.rotation);
            bulletLaze.transform.SetParent(transform);
        }
    }
}
