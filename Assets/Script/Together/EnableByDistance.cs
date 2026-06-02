using UnityEngine;

public class EnableByDistance : DameSender
{
    public GameObject mainCamera;
    public BulletController bulletContrl;
    protected override void Reset()
    {
        base.Reset();
        mainCamera = GameObject.Find("Main Camera");
        bulletContrl = GetComponent<BulletController>();
    }
    protected override void Awake()
    {
        base.Awake();
        mainCamera = GameObject.Find("Main Camera");
        bulletContrl = GetComponent<BulletController>();
    }
    private void Update()
    {
        if (Distance() > 70f)
        {
            SpawnBullet.instance.GoBackList(gameObject);
            gameObject.SetActive(false);
        }
    }
    public float Distance()
    {
        float dis = Vector3.Distance(transform.position, mainCamera.transform.position);
        return dis;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DameReceiver dameReceive = collision.GetComponent<DameReceiver>();
        if (dameReceive == null) return;
        SendDame(dameReceive);
        Vector3 newPos = transform.position;
        newPos.z = -5f;
        SpawnImpact.instance.SetPosition(SpawnImpact.instance.Impact, newPos, transform.rotation).transform.SetParent(bulletContrl.SpawnImpact.transform);
        gameObject.SetActive(false);
        SpawnBullet.instance.GoBackList(gameObject);
    }
}
