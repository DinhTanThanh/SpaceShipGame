using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnStartGame : BaseButton
{
    [SerializeField] protected MusicController musicController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMusicController();
    }
    protected virtual void LoadMusicController()
    {
        if (this.musicController != null) return;
        this.musicController=FindFirstObjectByType<MusicController>();
        Debug.LogWarning("Load MusicController: " + transform.name);
    }
    protected override void OnClick()
    {
        SoundFX.Instance.PlayOneShotSoundClick();
        this.musicController.MusicMainMenuBGM.TurnDownSound(0.4f);
        Invoke("LoadNextScene", 0.1f);
    }
    protected virtual void LoadNextScene()
    {
        SceneManager.LoadScene("LoadScene");
    }
}
