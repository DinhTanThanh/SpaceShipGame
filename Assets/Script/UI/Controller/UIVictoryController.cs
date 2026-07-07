using UnityEngine;

public class UIVictoryController : LoadMonoBehaviour
{
    [SerializeField] protected bool isShowUI = false;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeDelay = 2f;
    [SerializeField] protected GameObject uiWinGame;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIWinGame();
    }
    protected virtual void LoadUIWinGame()
    {
        if (this.uiWinGame != null) return;
        this.uiWinGame = GameObject.Find("UIWinGame");
        Debug.LogWarning("Load UIWinGame: " + transform.name);
    }
    private void Update()
    {
        if (!this.isShowUI) return;
        if (!this.Timing()) return;
        this.uiWinGame.SetActive(true);
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
        this.isShowUI= isShowUI;
    }
}
