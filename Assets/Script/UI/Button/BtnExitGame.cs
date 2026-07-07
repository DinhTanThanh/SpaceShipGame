using UnityEngine;

public class BtnExitGame : BaseButton
{
    [SerializeField] protected bool isOpen = false;
    [SerializeField] protected GameObject uiExitGame;
    [SerializeField] protected GameObject SoundClick;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIExitGame();
        this.LoadSoundClickGame();
    }
    protected virtual void LoadSoundClickGame()
    {
        if (this.SoundClick != null) return;
        this.SoundClick = GameObject.Find("SoundClick");
        Debug.LogWarning("Load SoundClick: " + transform.name);
    }
    protected virtual void LoadUIExitGame()
    {
        if (this.uiExitGame != null) return;
        this.uiExitGame = GameObject.Find("UIExitGame");
        Debug.LogWarning("Load UIExitGame: " + transform.name);
    }
    protected override void OnClick()
    {
        GameObject SoundClickUI = SpawnSoundClick.Instance.Spawn(this.SoundClick);
        SoundClickUI.SetActive(true);
        this.uiExitGame.SetActive(!this.isOpen);
        this.isOpen = !this.isOpen;
    }
    public virtual void SetIsOpen(bool isOpen)
    {
        this.isOpen = isOpen;
    }
}
