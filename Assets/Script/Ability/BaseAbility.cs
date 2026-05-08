using System.Threading;
using UnityEngine;

public class BaseAbility : LoadMonoBehaviour
{
    [Header("Base Ability")]
    [SerializeField] protected float timer;
    [SerializeField] protected float timeDelay;
    [SerializeField] protected bool isReady=false;
    public float Timer => timer;
    public float TimeDelay => timeDelay;
    public bool IsReady => isReady; 
    protected virtual void SetDelayTimer()
    {
        this.timer = 0f;
        this.timeDelay = 1f;
    }
    protected virtual bool Timing()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.timeDelay) return false;
        this.timer = 0f;
        return true;
    }
}
