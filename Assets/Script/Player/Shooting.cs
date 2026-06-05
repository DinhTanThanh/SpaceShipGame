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
        objectController = GetComponentInParent<PlayerController>();
        this.LoadShooter();
        bullet = GameObject.Find("Bullet");
        spawnBullett = GameObject.Find("SpawnBullet");
        this.GetListGatewayStatus();
        this.listGatewayStatus[0].SetStatusGateway(true);
        this.SetTimeDelay();
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
        //khi nhặt bullet sẽ hiển thị lên hotkey và người dùng chọn bắn đạn gì thì sẽ gán bulletCurrent sẽ là cái đó
        //cái này làm temp để game chạy được thôi (sẽ cải tiến sau) cách cải tiến là "sẽ override lại Spawn của pooling để nó spawn theo tên bullet hiện tại"
        //vòng lặp duyệt theo từng cổng và kiểm tra trạng thái của cổng
        //hiện tại code này đang vi phạm quy tắt DRY

        foreach(GatewayStatus gatewayStatus in this.listGatewayStatus)
        {
            if (gatewayStatus.StatusGetway)
            {
                this.SpawnShootingBullet(gatewayStatus.transform.position, gatewayStatus.transform.rotation);
            }   
        }

        //if (this.arrayStatusGateway[0])
        //{
        //    this.SpawnShootingBullet(this.shooter.transform.position, this.shooter.transform.rotation);
        //}
        //if (this.arrayStatusGateway[1])
        //{
        //    this.SpawnShootingBulletPink(this.shooter.transform.position, this.shooter.transform.rotation);
        //    Transform gatewayBullet_2 = this.objectController.PlayerGatewaysController.GatewayBullet_2;
        //    this.SpawnShootingBulletPink(gatewayBullet_2.position, gatewayBullet_2.rotation);
        //}
        //if (this.arrayStatusGateway[2])
        //{
        //    this.SpawnShootingBulletPink(this.shooter.transform.position, this.shooter.transform.rotation);
        //    Transform gatewayBullet_2 = this.objectController.PlayerGatewaysController.GatewayBullet_2;
        //    this.SpawnShootingBulletPink(gatewayBullet_2.position, gatewayBullet_2.rotation);
        //    Transform gatewayBullet_3 = this.objectController.PlayerGatewaysController.GatewayBullet_3;
        //    this.SpawnShootingBullet(gatewayBullet_3.position, gatewayBullet_3.rotation);
        //}
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
        if (objectController == null) return true;
        if (objectController.InputManager.clickMouse == 0) return false;
        return true;
    }
    protected override void SetTimeDelay()
    {
        this.timeDelay = 0.1f;
    }
}
