using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Shooting : Shoot
{
    [SerializeField] protected List<GatewayStatus> listGatewayStatus = new List<GatewayStatus>();
    [SerializeField] protected PlayerController objectController;
    public PlayerController ObjectController => objectController;
    protected override void LoadComponent()
    {
        this.objectController = GetComponentInParent<PlayerController>();
        this.LoadShooter();
        this.bullet = GameObject.Find("Bullet");
        this.spawnBullett = GameObject.Find("SpawnBullet");
        this.GetListGatewayStatus();
        this.listGatewayStatus[0].SetStatusGateway(true);
        this.SetTimeDelay(0.1f);
    }
    protected virtual void GetListGatewayStatus()
    {
        if (this.listGatewayStatus.Count > 0) return;
        foreach (Transform gateway in this.objectController.PlayerGatewaysController.transform)
        {
            GatewayStatus gatewayStatus = gateway.GetComponent<GatewayStatus>();
            if (gatewayStatus != null)
            {
                this.listGatewayStatus.Add(gatewayStatus);
            }
        }
    }
    public virtual void SetBulletCurrent(GameObject bulletCurrent)
    {
        this.bullet= bulletCurrent;
    }
    protected virtual void LoadShooter()
    {
        if (this.shooter != null) return;
        if (this.objectController == null) return;
        this.shooter = this.objectController.PlayerGatewaysController?.GatewayBullet_1?.gameObject;
        Debug.LogWarning("Load Shooter: " + transform.name);
    }
    public virtual void SetEnableStatusGateWay()
    {
        foreach(GatewayStatus gatewayStatus in this.listGatewayStatus)
        {
            if (!gatewayStatus.StatusGetway)
            {
                gatewayStatus.SetStatusGateway(true);
                return;
            }
        }
    }
    public virtual void SetDisableStatusGateway()
    {
        foreach (GatewayStatus gatewayStatus in this.listGatewayStatus)
        {
            if (gatewayStatus.name.Equals("GatewayBullet_1")) continue;
            if (gatewayStatus.StatusGetway)
            {
                gatewayStatus.SetStatusGateway(false);
                return;
            }
        }
    }
    public virtual bool GetListStatusGateWay(int index)
    {
        return this.listGatewayStatus[index].StatusGetway;
    }
    protected override void ExecuteSpawn()
    {
        foreach(GatewayStatus gatewayStatus in this.listGatewayStatus)
        {
            if (gatewayStatus.StatusGetway)
            {
                this.SpawnShootingBullet(gatewayStatus.transform.position, gatewayStatus.transform.rotation);
            }   
        }
    }
    protected virtual void SpawnShootingBullet(Vector3 position, Quaternion rotation)
    {
        GameObject bulletObject = SpawnBullet.instance.SetPosition(this.bullet, position, rotation);
        this.SetParent(bulletObject, SpawnBullet.instance.transform);
    }
    protected virtual void SpawnShootingBulletPink(Vector3 position, Quaternion rotation)
    {
        GameObject bulletObject = SpawnBulletPink.Instance.SetPosition(SpawnBulletPink.Instance.BulletPink, position, rotation);
        this.SetParent(bulletObject, SpawnBulletPink.Instance.transform);
    }
    protected virtual void SetParent(GameObject obj, Transform parent)
    {
        Vector3 pos = obj.transform.position;
        obj.transform.SetParent(parent);
        pos.z = 1f;
        obj.transform.position = pos;
    }
    private void Update()
    {
        TimeDelay();
    }
    protected override bool getControllerToSpawn()
    {
        if (this.objectController == null) return true;
        if (this.objectController.InputManager.clickMouse == 0) return false;
        return true;
    }
}
