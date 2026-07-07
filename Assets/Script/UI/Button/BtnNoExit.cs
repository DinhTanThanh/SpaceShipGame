using UnityEngine;

public class BtnNoExit : BaseButton
{
    [SerializeField] protected GameObject uiExitGame;
    [SerializeField] protected BtnExitGame btnExitGame;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIExitGame();
        this.LoadBtnExitGame();
    }
    protected virtual void LoadBtnExitGame()
    {
        if (this.btnExitGame != null) return;
        this.btnExitGame=FindFirstObjectByType<BtnExitGame>();
        Debug.LogWarning("Load BtnExitGame: " + transform.name);
    }
    protected virtual void LoadUIExitGame()
    {
        if (this.uiExitGame != null) return;
        this.uiExitGame = transform.parent.parent.gameObject;
        Debug.LogWarning("Load UIExitGame: " + transform.name);
    }
    protected override void OnClick()
    {
        this.uiExitGame.SetActive(false);
        this.btnExitGame.SetIsOpen(false);
    }
}
