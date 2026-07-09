using UnityEngine;

public class BulletYellowDameSender : DameSender
{
    [SerializeField] protected GameObject mainCamera;
    [SerializeField] protected BulletYellowController bulletYellowController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMainCamera();
        this.LoadBulletYellowController();
    }
    protected virtual void LoadMainCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = GameObject.Find("Main Camera");
        Debug.LogWarning("Load Main Camera: " + transform.name);
    }
    protected virtual void LoadBulletYellowController()
    {
        if (this.bulletYellowController != null) return;
        this.bulletYellowController = GetComponentInParent<BulletYellowController>();
        Debug.LogWarning("Load BulletYellowController: " + transform.name);
    }
    private void Update()
    {
        if (this.Distance() > 70f)
        {
            SpawnBulletYellow.Instance.GoBackList(transform.parent.gameObject);
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
        if (dameReceive is EnemySupportDameReceiver || dameReceive is EnergyShieldDameReceiver || dameReceive is BossFinalDameReceiver) return;
        SoundFX.Instance.PlayOneShotSoundImpact_2();
        this.SendDame(dameReceive, 1);
        Vector3 newPos = transform.parent.position;
        newPos.z = -5f;
        SpawnImpact.instance.SetPosition(SpawnImpact.instance.Impact, newPos, transform.rotation).transform.SetParent(bulletYellowController.SpawnImpact.transform);
        transform.parent.gameObject.SetActive(false);
        SpawnBulletYellow.Instance.GoBackList(transform.parent.gameObject);
    }
}
