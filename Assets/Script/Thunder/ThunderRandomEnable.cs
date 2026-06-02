using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ThunderRandomEnable : BaseThunder
{
    [SerializeField] protected List<Transform> listThunder;
    public List<Transform> ListThunder => listThunder;
    protected override void Reset()
    {
        base.Reset();
        this.GetListThunder();
        this.SetTimeDelay(1f,3f);
    }
    protected override void Awake()
    {
        base.Awake();
        this.GetListThunder();
    }
    private void Update()
    {
        this.OnEnableThunderByTime();
    }
    protected virtual void GetListThunder()
    {
        if (this.listThunder.Count > 0) return;
        foreach (Transform thunderChild in transform)
        {
            if (thunderChild == null) return;
            this.listThunder.Add(thunderChild);
        }
    }
    protected virtual void OnEnableThunderByTime()
    {
        if (!this.Timing()) return;
        this.RandomEnableThunder();
        this.SetTimeDelay(1f, 3f);
    }
    protected virtual void RandomEnableThunder()
    {
        int index = Random.Range(0, this.listThunder.Count);
        Transform thunder= this.listThunder[index];
        thunder.gameObject.SetActive(true);
    }
}
