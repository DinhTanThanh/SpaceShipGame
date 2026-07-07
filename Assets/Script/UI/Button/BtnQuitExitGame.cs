using UnityEngine;

public class BtnQuitExitGame : BaseButton
{
    [SerializeField] protected GameObject uiExitGame;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIExitGame();
    }
    protected virtual void LoadUIExitGame()
    {
        if (this.uiExitGame != null) return;
        this.uiExitGame = GameObject.Find("UIExitGame");
        Debug.LogWarning("Load UIExitGame: " + transform.name);
    }
    protected override void OnClick()
    {
        this.uiExitGame.SetActive(true);
    }
}
