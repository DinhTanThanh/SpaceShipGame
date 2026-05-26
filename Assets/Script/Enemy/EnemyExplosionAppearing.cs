using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosionAppearing : ObjAppearing
{
    [SerializeField] protected float startScale = 0f;
    [SerializeField] protected float currentScale = 0;
    [SerializeField] protected float speedScale = 0.001f;
    [SerializeField] protected float maxScale = 1f;
    [SerializeField] protected Transform enemyExplosion;
    [SerializeField] protected List<IObjAppearObserver> ListEnemyObserver=new List<IObjAppearObserver>();
    public Transform EnemyExplosion => enemyExplosion;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetCurrenSCale();
        this.InitScale();
        this.ObAppearObserverStart();   
        Debug.Log("Chayj");
    }
    private void Update()
    {
        this.Appearing();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyExplosion();
    }
    protected override void Appearing()
    {
        this.currentScale += this.speedScale;
        if (this.currentScale > this.maxScale)
        {
            this.isAppeared = true;
            this.ObAppearObserverEnd();
            return;
        }
        this.enemyExplosion.localScale = new Vector3(currentScale, currentScale, currentScale);
    }
    protected virtual void LoadEnemyExplosion()
    {
        if (this.enemyExplosion != null) return;
        this.enemyExplosion = transform.parent.GetComponent<Transform>();
        Debug.LogWarning("Load EnemyExplosion: " + transform.name);
    }
    protected virtual void ResetCurrenSCale()
    {
        this.currentScale = 0f;
    }
    public virtual void AddObjecrAppear(IObjAppearObserver objAppearObserver)
    {
        this.ListEnemyObserver.Add(objAppearObserver);
    }
    protected virtual void ObAppearObserverStart()
    {
        foreach(IObjAppearObserver appearObject in this.ListEnemyObserver)
        {
            appearObject.OnAppearStart();
        }
    }
    protected virtual void ObAppearObserverEnd()
    {
        foreach(IObjAppearObserver appearObject in this.ListEnemyObserver)
        {
            appearObject.OnAppearFinish();
        }
    }
    protected virtual void InitScale()
    {
        this.transform.parent.localScale = new Vector3(0, 0, 0);
    }
}
