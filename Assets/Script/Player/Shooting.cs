using UnityEngine;

public class Shooting : Shoot
{
    [SerializeField] protected PlayerController objectController;
    public PlayerController ObjectController => objectController;
    protected override void Reset()
    {
        LoadComponent();
    }
    protected override void Awake()
    {
        LoadComponent();
    }
    protected override void LoadComponent()
    {
        objectController = GetComponentInParent<PlayerController>();
        shooter = GameObject.Find(transform.parent.name);
        bullet = GameObject.Find("Bullet");
        spawnBullett = GameObject.Find("SpawnBullet");
    }
    protected override void ExecuteSpawn()
    {
        GameObject bulletObject = SpawnBullet.instance.SetPosition(bullet, shooter.transform.position, shooter.transform.rotation);
        Vector3 pos = bulletObject.transform.position;
        bulletObject.transform.SetParent(spawnBullett.transform);
        pos.z = 1f;
        bulletObject.transform.position = pos;
    }
    private void Update()
    {
        TimeDelay();
    }
    protected override bool getControllerToSpawn()
    {
        if (objectController == null) return true;
        if (objectController.inputManager.clickMouse == 0) return false;
        return true;
    }
}
