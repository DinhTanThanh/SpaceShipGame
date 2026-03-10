using UnityEngine;

public class EnableByTime : MonoBehaviour
{
    [SerializeField] private float timeLimit;
    public float TimeLimit
    {
        get { return timeLimit; }
        set { timeLimit = value; }
    }
    public float timer = 0f;
    public bool CheckAchieveLimit()
    {
        this.timer += Time.deltaTime;
        if (timer <= timeLimit) return false;
        this.timer = 0f;
        return true;
    }
    public virtual void SetLimitTime()
    {
        this.TimeLimit = 3f;
    }
}
