using UnityEngine;

public class PlayerGatewaysController : LoadMonoBehaviour
{
    [SerializeField] protected Transform gatewayBullet_1;
    [SerializeField] protected Transform gatewayBullet_2;
    [SerializeField] protected Transform gatewayBullet_3;
    [SerializeField] protected Transform supportPos;
    public Transform GatewayBullet_1=> gatewayBullet_1;
    public Transform GatewayBullet_2=> gatewayBullet_2;
    public Transform GatewayBullet_3=> gatewayBullet_3;
    public Transform SupportPos => supportPos;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSupportPos();
        this.LoadGatewayBullet_1();
        this.LoadGatewayBullet_2();
        this.LoadGatewayBullet_3();
    }
    protected virtual void LoadSupportPos()
    {
        if (this.supportPos != null) return;
        this.supportPos = transform.Find("SupportPos");
        Debug.LogWarning("Load SupportPos: " + transform.name);
    }
    protected virtual void LoadGatewayBullet_1()
    {
        if(this.gatewayBullet_1 != null) return;
        this.gatewayBullet_1 = transform.Find("GatewayBullet_1");
        Debug.LogWarning("Load GatewayBullet_1: "+transform.name);
    }
    protected virtual void LoadGatewayBullet_2()
    {
        if (this.gatewayBullet_2 != null) return;
        this.gatewayBullet_2 = transform.Find("GatewayBullet_2");
        Debug.LogWarning("Load GatewayBullet_2: " + transform.name);
    }
    protected virtual void LoadGatewayBullet_3()
    {
        if (this.gatewayBullet_3 != null) return;
        this.gatewayBullet_3 = transform.Find("GatewayBullet_3");
        Debug.LogWarning("Load GatewayBullet_3: " + transform.name);
    }
}
