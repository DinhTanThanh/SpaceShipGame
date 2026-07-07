using UnityEngine;

public class RoundLevel_3 : Round
{
    protected override void OnEnable()
    {
        this.SetStringLevel("LEVEL 3");
        this.ResetLocalScale();
        this.ActiveTextLevel();
    }
    private void Update()
    {
        this.EnableTextLevel();
    }
}
