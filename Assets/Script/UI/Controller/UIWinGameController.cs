using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class UIWinGameController : LoadMonoBehaviour
{
    [SerializeField] protected GameObject timeLine;
    [SerializeField] protected TextMeshProUGUI textMeshProUGUI;
    [SerializeField] protected CountTimeController countTimeController;
    [SerializeField] protected PlayerController playerController;
    [SerializeField] protected BtnActiveInventory btnActiveInventory;
    public BtnActiveInventory BtnActiveInventory => btnActiveInventory;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTimeLine();
        this.LoadTextMeshProUGUI();
        this.LoadCountTimeController();
        this.LoadPlayerController();
        this.LoadBtnActiveInventory();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        SoundFX.Instance.PlayOneShotSoundCompleteGame();
        this.GetElapsedTime();
        this.playerController.DisableAction();
        this.btnActiveInventory.gameObject.SetActive(false);
    }
    protected virtual void LoadBtnActiveInventory()
    {
        if (this.btnActiveInventory != null) return;
        this.btnActiveInventory = FindFirstObjectByType<BtnActiveInventory>();
        Debug.LogWarning("Load BtnActiveInventory; " + transform.name);
    }
    protected virtual void GetElapsedTime()
    {
        this.textMeshProUGUI.text = this.countTimeController.ConvertToMinute();
    }
    protected virtual void LoadPlayerController()
    {
        if (this.playerController != null) return;
        this.playerController = FindFirstObjectByType<PlayerController>();
        Debug.LogWarning("Load PlayerController: " + transform.name);
    }
    protected virtual void LoadCountTimeController()
    {
        if (this.countTimeController != null) return;
        this.countTimeController = FindFirstObjectByType<CountTimeController>();
        Debug.LogWarning("Load CountTimeController: " + transform.name);
    }
    protected virtual void LoadTextMeshProUGUI()
    {
        if (this.textMeshProUGUI != null) return;
        if (this.timeLine == null) return;
        this.textMeshProUGUI=this.timeLine.GetComponent<TextMeshProUGUI>();
        Debug.LogWarning("Load TextMeshProUGUI: " + transform.name);
    }
    protected virtual void LoadTimeLine()
    {
        if (this.timeLine != null) return;
        this.timeLine = transform.GetChild(0).Find("TimeLine").gameObject;
        Debug.LogWarning("Load TimeLine: "+transform.name);
    }
}
