using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossFinalShooting : LoadMonoBehaviour
{
    [SerializeField] protected bool isShootLaze = false;
    [SerializeField] protected bool isShootBullet = true;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeDelay = 0.5f;
    [SerializeField] protected int countShootBullet = 0;
    [SerializeField] protected int limitShootBullet = 10;
    [SerializeField] protected BossFinalController bossFinalController;
    public BossFinalController BossFinalController => bossFinalController;
    private void Update()
    {
        if (this.bossFinalController.PlayerController.DameReceiver.IsDead) return;
        if (this.isShootBullet)
        {
            this.BossFinalShootBullet();
        }
        if (this.isShootLaze)
        {
            this.BossFinalShootLaze();
        }
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossFinalController();
    }
    protected virtual void LoadBossFinalController()
    {
        if (this.bossFinalController != null) return;
        this.bossFinalController = GetComponentInParent<BossFinalController>();
        Debug.LogWarning("Load BossFinalController: " + transform.name);
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
    protected virtual void BossFinalShootLaze()
    {
        if (!this.Timing()) return;
        List<Transform> listGateway = this.bossFinalController.BossGateWayController.ListGateway;
        if (listGateway.Count <= 0) return;
        SoundFX.Instance.PlayOneShotSoundShootLaze();
        Transform gateway = listGateway[0];
        Vector3 pos = gateway.transform.position;
        GameObject bulletLaze = SpawnBulletLaze.Instance.SetPosition(SpawnBulletLaze.Instance.BulletLaze, pos, gateway.rotation);
        bulletLaze.transform.SetParent(transform);
        this.isShootLaze = false;
        Invoke("SetIsShootBullet", 3.2f);
    }
    protected virtual void SetIsShootBullet()
    {
        this.isShootBullet = true;
    }
    protected virtual void BossFinalShootBullet()
    {
        if (this.countShootBullet >= this.limitShootBullet)
        {
            this.isShootLaze = true;
            this.isShootBullet = false;
            this.countShootBullet = 0;
            return;
        }
        if (!this.Timing()) return;
        SoundFX.Instance.PlayOneShotSoundShoot();
        foreach(Transform gateway in this.bossFinalController.BossGateWayController.ListGateway)
        {
            Vector3 pos = gateway.transform.position;
            GameObject bulletGreen = SpawnBulletGreen.Instance.SetPosition(SpawnBulletGreen.Instance.BulletGreen, pos, gateway.rotation);
            bulletGreen.transform.SetParent(transform);
        }
        this.countShootBullet++;
    }
}
