using UnityEngine;

public class SoundEnableByTime : EnableByTime
{
    private void Reset()
    {
        this.SetLimitTime();
    }
    public override void SetLimitTime()
    {
        this.TimeLimit = 1f;
    }
    private void Update()
    {
        if (!this.CheckAchieveLimit()) return;
        this.transform.parent.gameObject.SetActive(false);
        SpawnSoundClick.Instance.GoBackList(this.transform.parent.gameObject);
    }
}
