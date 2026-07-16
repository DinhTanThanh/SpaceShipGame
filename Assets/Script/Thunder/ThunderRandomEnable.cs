using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ThunderRandomEnable : BaseThunder
{
    [SerializeField] protected List<Transform> listThunder;
    [SerializeField] protected UIWinGameController uiWinGameController;
    public List<Transform> ListThunder => listThunder;
    protected override void Reset()
    {
        base.Reset();
        this.GetListThunder();
        this.SetTimeDelay(6f,10f);
    }
    protected override void Awake()
    {
        base.Awake();
        this.GetListThunder();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIWinGameController();
    }
    protected virtual void LoadUIWinGameController()
    {
        if (this.uiWinGameController != null) return;
        this.uiWinGameController = FindFirstObjectByType<UIWinGameController>();
        Debug.LogWarning("Load UIWinGameController: " + transform.name);
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
        if (this.uiWinGameController.gameObject.activeSelf) return;
        if (!this.Timing()) return;
        this.RandomEnableThunder();
        this.SetTimeDelay(6f, 10f);
    }
    protected virtual void RandomEnableThunder()
    {
        int index = Random.Range(0, this.listThunder.Count);
        Transform thunder= this.listThunder[index];
        thunder.gameObject.SetActive(true);
    }
}
