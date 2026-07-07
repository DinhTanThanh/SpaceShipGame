using UnityEngine;

public class RoundLevel_2 : Round
{
    protected override void OnEnable()
    {
        this.SetStringLevel("LEVEL 2");
        this.ResetLocalScale();
        this.ActiveTextLevel();
    }
    private void Update()
    {
        this.EnableTextLevel();
    }
}
