using UnityEngine;

public abstract class Shoot : LoadMonoBehaviour
{
    public float timer = 0f;
    public float timeDelay = 0.5f;

    [SerializeField] protected GameObject shooter;
    public GameObject Shooter => shooter;
    [SerializeField] protected GameObject bullet;
    public GameObject Bullet=> bullet;
    [SerializeField] protected GameObject spawnBullett;
    public GameObject SpawnBullett=>spawnBullett;
 
    protected abstract bool GetControllerToSpawn();
    protected virtual void TimeDelay()
    {
        this.timer += Time.deltaTime;
        if (this.timer < timeDelay) return;
        this.timer = 0f;
        if (!GetControllerToSpawn()) return;
        ExecuteSpawn();
    }
    protected abstract void ExecuteSpawn();
    public virtual void SetTimeDelay(float timeDelay)
    {
        this.timeDelay = timeDelay;
    }
}
