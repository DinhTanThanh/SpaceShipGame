using UnityEngine;

public class ExplosionFireEnableByTime : EnableByTime
{
    private void Reset()
    {
        this.SetLimitTime();
    }
    public override void SetLimitTime()
    {
        this.TimeLimit = 1.8f;
    }
    private void Update()
    {
        if (!this.CheckAchieveLimit()) return;
        this.transform.parent.gameObject.SetActive(false);
    }
}
