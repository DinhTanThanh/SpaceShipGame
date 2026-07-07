using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class SummonSupportShipSkill : BaseSkill
{
    [SerializeField] protected bool isOpen = false;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float delayTime = 60f;
    [SerializeField] protected Transform supportShip;
    [SerializeField] protected Transform managerSupportShip;
    [SerializeField] protected DameReceiver dameReceiver;
    [SerializeField] protected TextMeshProUGUI textMeshProUGUI;
    public bool IsOpen => isOpen;
    public Transform SupportShip => supportShip;
    public Transform ManagerSupportShip => managerSupportShip;
    private void Update()
    {
        if (!this.isOpen) return;
        this.timer += Time.deltaTime;
        string countDown = (this.delayTime - this.timer).ToString("F2") + "s";
        this.textMeshProUGUI.text = countDown;
        if (this.timer < delayTime) return;
        this.timer = 0f;
        this.isOpen = false;
        this.textMeshProUGUI.text = "";
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadManagerSupportShip();
        this.LoadSupportShip();
        this.LoadDameReceiver();
        this.LoadTextMeshProUGUI();
    }
    public virtual void SetIsOpen(bool isOpen)
    {
        this.isOpen = isOpen;
    }
    protected virtual void LoadTextMeshProUGUI()
    {
        if (this.textMeshProUGUI != null) return;
        this.textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning("Load TextMeshProUGUI: " + transform.name);
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
        if (this.isOpen) return;
        bool statusSkill = !this.isOpen;
        this.supportShip.gameObject.SetActive(statusSkill);
        this.dameReceiver.Reborn();
        this.isOpen = statusSkill;
    }
}
