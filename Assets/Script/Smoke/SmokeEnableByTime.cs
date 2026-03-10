using UnityEngine;

public class SmokeEnableByTime : EnableByTime
{
    private void Reset()
    {
        SetLimitTime();
    }
    private void Awake()
    {
        SetLimitTime();
    }
    private void Update()
    {
        EnableObject();
    }
    public override void SetLimitTime()
    {
        this.TimeLimit = 0.4f;
    }
    public void EnableObject()
    {
        if (!CheckAchieveLimit()) return;
        gameObject.SetActive(false);
        SpawnSmoke.instance.GoBackList(gameObject);
    }
}
