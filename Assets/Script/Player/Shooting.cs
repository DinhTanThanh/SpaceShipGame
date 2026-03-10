using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float timer = 0f;
    public float timeDelay = 0.5f;
    public GameObject player;
    public GameObject bullet;
    public GameObject SpawnBullett;
    public PlayerController playerController;
    private void Reset()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        player = GameObject.Find("Player");
        bullet = GameObject.Find("Bullet");
        SpawnBullett = GameObject.Find("SpawnBullett");
    }
    private void Awake()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        player = GameObject.Find("Player");
        bullet = GameObject.Find("Bullet");
        SpawnBullett = GameObject.Find("SpawnBullett");
        bullet.SetActive(false);
    }
    private void Update()
    {
        TimeDelay();
    }
    public void TimeDelay()
    {
        timer += Time.deltaTime;
        if (playerController.inputManager.clickMouse == 0) return;
        if (timer < timeDelay) return;
        timer = 0f;
        GameObject bulletObject= SpawnBullet.instance.SetPosition(bullet, player.transform.position, player.transform.rotation);
        Vector3 pos = bulletObject.transform.position;
        bulletObject.transform.SetParent(SpawnBullett.transform);
        pos.z = 1f;
        bulletObject.transform.position= pos;
    }
}
