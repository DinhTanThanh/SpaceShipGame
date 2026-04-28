using System.Collections.Generic;
using UnityEngine;

public class EnemyAppearingBigger : ObjAppearing
{
    [Header("Enemy AppearingBigger")]
    [SerializeField] protected float currentScale = 0f;
    [SerializeField] protected float startScale = 0.1f;
    [SerializeField] protected float speedScale = 0.001f;
    [SerializeField] protected float maxScale = 1f;
    [SerializeField] protected List<IObjAppearObserver> observers= new List<IObjAppearObserver>();
    [SerializeField] protected bool checkEnable = false;
    protected override void OnEnable()
    {
        InitScale();
        if (checkEnable)
        {
            this.OnAppearStart();
        }
    }
    protected override void Start()
    {
        //Debug.Log("1");
        this.OnAppearStart();
        this.checkEnable = true;
    }
    private void Update()
    {
        Appearing();
    }
    protected override void Appearing()
    {
        if (currentScale >= maxScale)
        {
            IsAppeared();
            return;
        }
        this.currentScale += this.speedScale;
        transform.parent.localScale = new Vector3(this.currentScale, this.currentScale, this.currentScale);
    }
    protected void InitScale()
    {
        transform.parent.localScale = Vector3.zero;
        this.currentScale = this.startScale;
    }
    protected override void IsAppeared()
    {
        base.IsAppeared();
        transform.parent.localScale = new Vector3(this.maxScale, this.maxScale, this.maxScale);
        this.OnAppearFinish();
    }
    public virtual void ObserverAdd(IObjAppearObserver observer)
    {
        this.observers.Add(observer);
    }
    public virtual void OnAppearStart()
    {
        foreach(IObjAppearObserver objAppearObserver in this.observers)
        {
            objAppearObserver.OnAppearStart();
        }
    }
    public virtual void OnAppearFinish()
    {
        foreach(IObjAppearObserver objAppearObserver in this.observers)
        {
            objAppearObserver.OnAppearFinish();
        }
    }
}
