using UnityEngine;

public class BtnExitGame : BaseButton
{
    [SerializeField] protected bool isOpen = false;
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
        SoundFX.Instance.PlayOneShotSoundClick();
        this.uiExitGame.SetActive(!this.isOpen);
        this.isOpen = !this.isOpen;
    }
    public virtual void SetIsOpen(bool isOpen)
    {
        this.isOpen = isOpen;
    }
}
