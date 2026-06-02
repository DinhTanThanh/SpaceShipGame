using UnityEngine;

public class ThunderDisableByTime : BaseThunder
{
    protected override void Reset()
    {
        base.Reset();
        this.SetTimeDelay(0.2f,0.4f);
    }
    private void Update()
    {
        this.DisableByTime();
    }
    protected virtual void DisableByTime()
    {
        if (!this.Timing()) return;
        this.transform.parent.gameObject.SetActive(false);
    }
    
}
