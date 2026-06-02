using System.ComponentModel;
using UnityEngine;
using UnityEngine.Rendering;

public class SummonSupportShipSkill : BaseSkill
{
    [SerializeField] protected bool isOpen = false;
    public bool IsOpen => isOpen;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float delayTime = 10f;
    [SerializeField] protected Transform supportShip;
    public Transform SupportShip => supportShip;

    [SerializeField] protected Transform managerSupportShip;
    public Transform ManagerSupportShip => managerSupportShip;
    [SerializeField] DameReceiver dameReceiver;
    private void Update()
    {
        if (!this.dameReceiver.IsDead) return;
        this.timer += Time.deltaTime;
        if (this.timer < delayTime) return;
        this.timer = 0f;
        this.dameReceiver.Reborn();
        this.isOpen = false;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadManagerSupportShip();
        this.LoadSupportShip();
        this.LoadDameReceiver();
    }   
    protected virtual void LoadDameReceiver()
    {
        if (this.dameReceiver != null) return;
        this.dameReceiver=this.supportShip.GetComponentInChildren<DameReceiver>();
        Debug.LogWarning("Load DameReceiver: " + transform.name);
    }
    protected virtual void LoadManagerSupportShip()
    {
        if (this.managerSupportShip != null) return;
        this.managerSupportShip = GameObject.Find("ManagerSupportShip")?.transform;
        Debug.LogWarning("Load ManagerSupportShip: " + transform.name);
    }
    protected virtual void LoadSupportShip()
    {
        if (this.supportShip != null) return;
        this.supportShip = this.ManagerSupportShip.transform.Find("SupportShip");
        Debug.LogWarning("Load SupportShip: " + transform.name);
    }
    protected virtual void SetDelayTime(float timeDelay)
    {
        this.delayTime = timeDelay;
    }
    public override void ActiveSkill()
    {
        if (this.dameReceiver.IsDead) return;
        bool statusSkill = !this.isOpen;
        this.supportShip.gameObject.SetActive(statusSkill);
        this.isOpen = statusSkill;
    }
}
