using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseThunder : LoadMonoBehaviour
{
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float timeDelay = 1f;
    protected virtual void SetTimeDelay(float minTimeDelay,float maxTimeDelay)
    {
        float timeDelay = this.RandomTimeDelay(minTimeDelay, maxTimeDelay);
        this.timeDelay = timeDelay;
    }
    protected virtual bool Timing()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.timeDelay) return false;
        this.timer = 0f;
        return true;
    }
    protected virtual float RandomTimeDelay(float minDelay,float maxDelay)
    {
        return Random.Range(minDelay, maxDelay);
    }
}
