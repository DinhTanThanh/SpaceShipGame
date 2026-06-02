using UnityEngine;

public class ExplosionEnableByTime : EnableByTime
{
    private void Reset()
    {
        this.SetLimitTime();
    }
    private void Awake()
    {
        this.SetLimitTime();
    }
    private void Update()
    {
        this.CheckEnableExplosion();
    }
    public override void SetLimitTime()
    {
        this.TimeLimit = 1f;
    }
    protected virtual void CheckEnableExplosion()
    {
        if (!this.CheckAchieveLimit()) return;
        transform.parent.gameObject.SetActive(false);
        SpawnExplosion.Instance.GoBackList(transform.parent.gameObject);
    }
}
