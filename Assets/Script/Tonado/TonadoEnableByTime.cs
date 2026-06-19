using UnityEngine;

public class TonadoEnableByTime : EnableByTime
{
    private void Reset()
    {
        this.SetLimitTime();
    }
    private void Update()
    {
        if (!this.CheckAchieveLimit()) return;
        SpawnTonado.Instance.GoBackList(transform.parent.gameObject);
        this.transform.parent.gameObject.SetActive(false);
    }
    public override void SetLimitTime()
    {
        this.TimeLimit = 3f;
    }
}
