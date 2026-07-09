using UnityEngine;

public class BulletPinkDameSender : DameSender
{
    public GameObject mainCamera;
    [SerializeField] protected BulletPinkController bulletController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMainCamera();
        this.LoadBulletPinkController();
    }
    protected virtual void LoadMainCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = GameObject.Find("Main Camera");
        Debug.LogWarning("Load Main Camera: "+transform.name);
    }
    protected virtual void LoadBulletPinkController()
    {
        if (this.bulletController != null) return;
        this.bulletController = GetComponentInParent<BulletPinkController>();
        Debug.LogWarning("Load BulletPinkController: " + transform.name);
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
        SoundFX.Instance.PlayOneShotSoundImpact_2();
        SendDame(dameReceive,1);
        Vector3 newPos = transform.position;
        newPos.z = -5f;
        SpawnImpact.instance.SetPosition(SpawnImpact.instance.Impact, newPos, transform.rotation).transform.SetParent(bulletController.SpawnImpact.transform);
        transform.parent.gameObject.SetActive(false);
        SpawnBullet.instance.GoBackList(transform.parent.gameObject);
    }
}
