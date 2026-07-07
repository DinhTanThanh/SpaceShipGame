using UnityEngine;

public class RoundLevel_1 : Round
{
    protected override void OnEnable()
    {
        this.SetStringLevel("LEVEL 1");
        this.ResetLocalScale();
        this.ActiveTextLevel();
    }
    private void Update()
    {
        this.EnableTextLevel();
    }
}
