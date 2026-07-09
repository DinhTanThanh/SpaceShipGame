using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnStartGame : BaseButton
{
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
    }
    protected override void OnClick()
    {
        SoundFX.Instance.PlayOneShotSoundClick();
        Invoke("LoadNextScene", 0.1f);
    }
    protected virtual void LoadNextScene()
    {
        SceneManager.LoadScene("LoadScene");
    }
}
