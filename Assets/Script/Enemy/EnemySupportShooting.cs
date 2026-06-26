using UnityEngine;

public class EnemySupportShooting : LoadMonoBehaviour
{
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeDelay = 0.6f;
    private void Update()
    {
        if (!this.Timing()) return;
        Vector3 pos = this.transform.parent.position;
        Quaternion rot = this.transform.parent.rotation;
        rot = rot * Quaternion.Euler(0, 0, 5f);
        SpawnBulletViolet.Instance.SetPosition(SpawnBulletViolet.Instance.BulletViolet, pos, rot);
    }
    protected virtual bool Timing()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.timeDelay) return false;
        this.timer = 0f;
        return true;
    }
}
