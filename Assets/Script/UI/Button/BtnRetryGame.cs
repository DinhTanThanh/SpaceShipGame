using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnRetryGame : BaseButton
{
    [SerializeField] protected LevelController levelController;
    [SerializeField] protected GameObject uiGameController;
    [SerializeField] protected BtnNextLevel btnNextLevel;
    [SerializeField] protected PlayerController playerController;
    [SerializeField] protected CountTimeController countTimeController;
    [SerializeField] protected BtnActiveInventory btnActiveInventory;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadLevelController();
        this.LoadUIGameController();
        this.LoadBtnNextLevel();
        this.LoadPlayerController();
        this.LoadCountTimeController();
        this.LoadBtnActiveInventory();
    }
    protected virtual void LoadBtnActiveInventory()
    {
        if (this.btnActiveInventory != null) return;
        this.btnActiveInventory = FindFirstObjectByType<BtnActiveInventory>();
        Debug.LogWarning("Load BtnActiveInventory; " + transform.name);
    }
    protected virtual void LoadCountTimeController()
    {
        if (this.countTimeController != null) return;
        this.countTimeController = FindFirstObjectByType<CountTimeController>();
        Debug.LogWarning("Load CountTimeController: " + transform.name);
    }
    protected virtual void LoadPlayerController()
    {
        if (this.playerController != null) return;
        this.playerController = FindFirstObjectByType<PlayerController>();
        Debug.LogWarning("Load BtnNextLevel: " + transform.name);
    }
    protected virtual void LoadBtnNextLevel()
    {
        if (this.btnNextLevel != null) return;
        this.btnNextLevel = FindFirstObjectByType<BtnNextLevel>();
        Debug.LogWarning("Load BtnNextLevel: " + transform.name);
    }
    protected virtual void LoadUIGameController()
    {
        if (this.uiGameController != null) return;
        this.uiGameController = transform.parent.parent.gameObject;
        Debug.LogWarning("Load UIGame: " + transform.name);
    }
    protected virtual void LoadLevelController()
    {
        if (this.levelController != null) return;
        this.levelController=FindFirstObjectByType<LevelController>();
        Debug.LogWarning("Load LevelController: " + transform.name);
    }
    protected override void OnClick()
    {
        SoundFX.Instance.PlayOneShotSoundClick();
        this.playerController.gameObject.SetActive(true);
        this.playerController.DameReceiver.ResetKi(this.playerController.DameReceiver.MaxKI);
        Transform level = levelController.GetLevelCurrent();
        BaseLevel baseLevel = level.GetComponent<BaseLevel>();
        baseLevel.RebornLevel();
        this.levelController.ActiveLevelCurrent();
        this.uiGameController.SetActive(false);
        Debug.Log(this.btnNextLevel.HpBeginLevel);
        this.playerController.DameReceiver.SetMaxHpAndHp(this.btnNextLevel.HpBeginLevel, this.btnNextLevel.HpBeginLevel);
        this.transform.parent.parent.gameObject.SetActive(false);
        this.countTimeController.ResetTimer();
        this.playerController.ActiveAction();
        this.btnActiveInventory.gameObject.SetActive(true);
    }
}
