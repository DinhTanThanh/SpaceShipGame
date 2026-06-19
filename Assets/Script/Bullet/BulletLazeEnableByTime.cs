using UnityEngine;

public class BulletLazeEnableByTime : EnableByTime
{
    private void Reset()
    {
        this.SetLimitTime();
    }
    public override void SetLimitTime()
    {
        this.TimeLimit = 4f;
    }
    private void Update()
    {
        if (!this.CheckAchieveLimit()) return;
        Debug.Log("offf");
        SpawnBulletLaze.Instance.GoBackList(transform.parent.gameObject);
        transform.parent.gameObject.SetActive(false);
    }
}
