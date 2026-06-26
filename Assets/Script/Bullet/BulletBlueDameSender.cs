using UnityEngine;

public class BulletBlueDameSender : DameSender
{
    [SerializeField] protected GameObject mainCamera;
    [SerializeField] protected BulletBlueController bulletController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMainCamera();
        this.LoadBulletBlueController();
    }
    protected virtual void LoadMainCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = GameObject.Find("Main Camera");
        Debug.LogWarning("Load Main Camera: " + transform.name);
    }
    protected virtual void LoadBulletBlueController()
    {
        if (this.bulletController != null) return;
        this.bulletController = GetComponentInParent<BulletBlueController>();
        Debug.LogWarning("Load BulletBlueController: " + transform.name);
    }
    private void Update()
    {
        if (this.Distance() > 70f)
        {
            SpawnBullet.instance.GoBackList(transform.parent.gameObject);
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
        if (dameReceive is PlayerDameReceiver) return;
        SendDame(dameReceive);
        Vector3 newPos = transform.position;
        newPos.z = -5f;
        SpawnImpact.instance.SetPosition(SpawnImpact.instance.Impact, newPos, transform.rotation).transform.SetParent(bulletController.SpawnImpact.transform);
        transform.parent.gameObject.SetActive(false);
        SpawnBullet.instance.GoBackList(transform.parent.gameObject);
    }
}
