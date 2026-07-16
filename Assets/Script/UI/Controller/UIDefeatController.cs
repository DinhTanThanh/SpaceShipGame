using UnityEngine;

public class UIDefeatController : LoadMonoBehaviour
{
    [SerializeField] protected bool isShowUI = false;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeDelay = 2f;
    [SerializeField] protected GameObject uiDefeatGame;
    [SerializeField] protected UIVictoryController uiVictoryController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIDefeatGame();
        this.LoadUIVictoryController();
    }
    protected virtual void LoadUIVictoryController()
    {
        if (this.uiVictoryController != null) return;
        this.uiVictoryController = FindFirstObjectByType<UIVictoryController>();
        Debug.LogWarning("Load UIVictoryController: " + transform.name);
    }
    protected virtual void LoadUIDefeatGame()
    {
        if (this.uiDefeatGame != null) return;
        this.uiDefeatGame = GameObject.Find("UILoseGame");
        Debug.LogWarning("Load UILoseGame: " + transform.name);
    }
    private void Update()
    {
        if (!this.isShowUI) return;
        this.uiVictoryController.SetIsShowUI(false);
        this.uiDefeatGame.SetActive(true);
        this.isShowUI = false;
    }
    protected virtual bool Timing()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.timeDelay) return false;
        this.timer = 0f;
        return true;
    }
    public virtual void SetIsShowUI(bool isShowUI)
    {
        this.isShowUI = isShowUI;
    }
}
