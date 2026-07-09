using UnityEngine;

public class EnemySupportV2Shooting : LoadMonoBehaviour
{
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeDelay = 0.6f;
    private void Update()
    {
        if (!this.Timing()) return;
        SoundFX.Instance.PlayOneShotSoundShoot();
        Vector3 pos = this.transform.parent.position;
        Quaternion rot = this.transform.parent.rotation;
        rot = rot * Quaternion.Euler(0, 0, -5f);
        SpawnBulletYellow.Instance.SetPosition(SpawnBulletYellow.Instance.BulletYellow, pos, rot);
    }
    protected virtual bool Timing()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.timeDelay) return false;
        this.timer = 0f;
        return true;
    }
}
