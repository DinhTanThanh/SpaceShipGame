using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnRetryGame : BaseButton
{
    [SerializeField] protected LevelController levelController;
    [SerializeField] protected GameObject uiGameController;
    [SerializeField] protected BtnNextLevel btnNextLevel;
    [SerializeField] protected PlayerController playerController;
    [SerializeField] protected CountTimeController countTimeController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadLevelController();
        this.LoadUIWinGameController();
        this.LoadBtnNextLevel();
        this.LoadPlayerController();
        this.LoadCountTimeController();
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
    protected virtual void LoadUIWinGameController()
    {
        if (this.uiGameController != null) return;
        this.uiGameController = transform.parent.parent.gameObject;
        Debug.LogWarning("Load UIWinGame: " + transform.name);
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
        this.playerController.DameReceiver.SetMaxHpAndHp(this.btnNextLevel.HpBeginLevel, this.btnNextLevel.HpBeginLevel);
        this.transform.parent.parent.gameObject.SetActive(false);
        this.countTimeController.ResetTimer();
    }
}
