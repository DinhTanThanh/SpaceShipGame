using UnityEngine;

public class SupportShipEnableByTime : EnableByTime
{
    private void Reset()
    {
        this.SetLimitTime();
    }
    public override void SetLimitTime()
    {
        this.TimeLimit = 30f;
    }
    private void Update()
    {
        if (!this.CheckAchieveLimit()) return;
        this.transform.parent.gameObject.SetActive(false);
    }
}
