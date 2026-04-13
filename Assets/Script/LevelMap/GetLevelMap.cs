using UnityEngine;

public class GetLevelMap : LevelByDistance
{
    private void Reset()
    {
        GetTarget();
    }
    private void Awake()
    {
        GetTarget();
    }
    private void FixedUpdate()
    {
        DistanceCurrent();
    }
}
