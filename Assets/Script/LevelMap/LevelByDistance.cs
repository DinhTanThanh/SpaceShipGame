using UnityEngine;

public class LevelByDistance : Level
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float disCurrent=0;
    [SerializeField] protected float disLevelUp = 10f;
    
    protected void GetTarget()
    {
        target = GameObject.Find("Player")?.transform;
    }
    protected void DistanceCurrent()
    {
        if (target == null) return;
        this.disCurrent = Vector3.Distance(transform.position, target.position);
        SetLevelCurrent(disCurrent);
    }
    protected void SetLevelCurrent(float dis)
    {
        int newLevel = Mathf.CeilToInt(disCurrent/disLevelUp);
        LevelUp(newLevel);
    }
}
