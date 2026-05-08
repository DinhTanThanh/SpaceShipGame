using UnityEngine;

public class EnableByDistance : DamgeSender
{
    public GameObject mainCamera;
    public BulletController bulletContrl;
    private void Reset()
    {
        mainCamera = GameObject.Find("Main Camera");
        bulletContrl = GetComponent<BulletController>();
    }
    private void Awake()
    {
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
        if (collision.GetComponentInChildren<MeoteoriteDamereceiver>())
        {
            MeoteoriteDamereceiver dameReceiver = collision.GetComponentInChildren<MeoteoriteDamereceiver>();
            SendDame(dameReceiver);
        }
        else if (collision.GetComponentInChildren<EnemyDameReceiver>())
        {
            EnemyDameReceiver dameReceiver = collision.GetComponentInChildren<EnemyDameReceiver>();
            SendDame(dameReceiver);
        }
        else if (collision.GetComponentInChildren<EnemyMotherDameReceiver>())
        {
            EnemyMotherDameReceiver dameReceiver = collision.GetComponentInChildren<EnemyMotherDameReceiver>();
            SendDame(dameReceiver);
        }
        else
        {
            return;
        }
        Vector3 newPos = transform.position;
        newPos.z = -5f;
        SpawnImpact.instance.SetPosition(SpawnImpact.instance.Impact, newPos, transform.rotation).transform.SetParent(bulletContrl.SpawnImpact.transform);
        gameObject.SetActive(false);
        SpawnBullet.instance.GoBackList(gameObject);
    }
}
