using UnityEngine;

public class BtnNextLevel : BaseButton
{
    [SerializeField] protected int hpBeginLevel;
    [SerializeField] protected CountTimeController countTimeController;
    [SerializeField] protected LevelController levelController;
    [SerializeField] protected PlayerController playerController;
    public int HpBeginLevel => hpBeginLevel;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCountTimeController();
        this.LoadLevelController();
        this.LoadPlayerController();
        //this.GetHpBeginLevel();
    }
    protected virtual void GetHpBeginLevel()
    {
        if (this.playerController == null) return;
        this.hpBeginLevel=this.playerController.DameReceiver.MaxHp;
        Debug.LogWarning("Get HpBeginLevel: " + transform.name);
    }
    protected virtual void LoadPlayerController()
    {
        if (this.playerController != null) return;
        this.playerController = FindFirstObjectByType<PlayerController>();
        Debug.LogWarning("Load PlayerController: " + transform.name);
    }
    protected virtual void LoadLevelController()
    {
        if (this.levelController != null) return;
        this.levelController = FindFirstObjectByType<LevelController>();
        Debug.LogWarning("Load LevelController: "+transform.name);
    }
    protected virtual void LoadCountTimeController()
    {
        if (this.countTimeController != null) return;
        this.countTimeController = FindFirstObjectByType<CountTimeController>();
        Debug.LogWarning("Load CountTimeController: " + transform.name);
    }
    protected override void OnClick()
    {
        if (this.levelController.CheckLimitLevel())
        {
            Debug.Log("Dat gioi han level");
            return;
        }
        this.SetBossCurrent();
        Transform levelCurrent = this.levelController.GetLevelCurrent();
        BaseLevel level=levelCurrent.GetComponent<BaseLevel>();
        ShootingController boss=level.GetBossLevel();
        this.countTimeController.SetBossCurrent(boss);
        this.levelController.ActiveLevelCurrent();
        this.GetHpBeginLevel();
        this.transform.parent.parent.gameObject.SetActive(false);
        this.countTimeController.ResetTimer();
    }
    protected virtual void SetBossCurrent()
    {
        int levelCurrent = this.levelController.GetNumberLevelCurrent()+1;
        this.levelController.SetLevelCurrent(levelCurrent);
    }
}
