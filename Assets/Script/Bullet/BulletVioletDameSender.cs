using UnityEngine;

public class BulletVioletDameSender : DameSender
{
    [SerializeField] protected GameObject mainCamera;
    [SerializeField] protected BulletVioletController bulletVioletController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMainCamera();
        this.LoadBulletVioletController();
    }
    protected virtual void LoadMainCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = GameObject.Find("Main Camera");
        Debug.LogWarning("Load Main Camera: " + transform.name);
    }
    protected virtual void LoadBulletVioletController()
    {
        if (this.bulletVioletController != null) return;
        this.bulletVioletController = GetComponentInParent<BulletVioletController>();
        Debug.LogWarning("Load BulletVioletController: " + transform.name);
    }
    private void Update()
    {
        if (this.Distance() > 70f)
        {
            SpawnBulletViolet.Instance.GoBackList(transform.parent.gameObject);
            transform.parent.gameObject.SetActive(false);
        }
    }
    public float Distance()
    {
        float dis = Vector3.Distance(transform.parent.position, mainCamera.transform.position);
        return dis;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DameReceiver dameReceive = collision.GetComponent<DameReceiver>();
        if (dameReceive == null) return;
        if (dameReceive is EnemySupportDameReceiver|| dameReceive is EnergyShieldDameReceiver || dameReceive is BossFinalDameReceiver) return;
        this.SendDame(dameReceive,1);
        Vector3 newPos = transform.parent.position;
        newPos.z = -5f;
        SpawnImpact.instance.SetPosition(SpawnImpact.instance.Impact, newPos, transform.rotation).transform.SetParent(bulletVioletController.SpawnImpact.transform);
        transform.parent.gameObject.SetActive(false);
        SpawnBulletViolet.Instance.GoBackList(transform.parent.gameObject);
    }
}
