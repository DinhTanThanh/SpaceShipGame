using UnityEngine;

public class BtnYesExit : BaseButton
{
    protected override void OnClick()
    {
        SoundFX.Instance.PlayOneShotSoundClick();
        Invoke("QuitGame", 0.1f);
    }
    protected virtual void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
