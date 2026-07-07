using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnStartGame : BaseButton
{
    [SerializeField] protected GameObject SoundClick;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSoundClickGame();
    }
    protected virtual void LoadSoundClickGame()
    {
        if (this.SoundClick != null) return;
        this.SoundClick = GameObject.Find("SoundClick");
        Debug.LogWarning("Load SoundClick: " + transform.name);
    }
    protected override void OnClick()
    {
        GameObject SoundClickUI= SpawnSoundClick.Instance.Spawn(this.SoundClick);
        SoundClickUI.SetActive(true);
        SceneManager.LoadScene("LoadScene");
    }
}
