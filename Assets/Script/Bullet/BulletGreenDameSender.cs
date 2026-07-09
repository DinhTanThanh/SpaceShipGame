using UnityEngine;

public class BulletGreenDameSender : DameSender
{
    [SerializeField] protected GameObject mainCamera;
    [SerializeField] protected BulletGreenController bulletGreenController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMainCamera();
        this.LoadBulletGreenController();
    }
    protected virtual void LoadMainCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = GameObject.Find("Main Camera");
        Debug.LogWarning("Load Main Camera: " + transform.name);
    }
    protected virtual void LoadBulletGreenController()
    {
        if (this.bulletGreenController != null) return;
        this.bulletGreenController = GetComponentInParent<BulletGreenController>();
        Debug.LogWarning("Load BulletGreenController: " + transform.name);
    }
    private void Update()
    {
        if (this.Distance() > 70f)
        {
            SpawnBulletGreen.Instance.GoBackList(transform.parent.gameObject);
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
        if (dameReceive is EnergyShieldDameReceiver ||dameReceive is BossFinalDameReceiver) return;
        SoundFX.Instance.PlayOneShotSoundImpact_2();
        this.SendDame(dameReceive,1);
        Vector3 newPos = transform.parent.position;
        newPos.z = -5f;
        SpawnImpact.instance.SetPosition(SpawnImpact.instance.Impact, newPos, transform.rotation).transform.SetParent(bulletGreenController.SpawnImpact.transform);
        transform.parent.gameObject.SetActive(false);
        SpawnBulletGreen.Instance.GoBackList(transform.parent.gameObject);
    }
}
