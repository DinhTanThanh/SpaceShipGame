using UnityEngine;

public class BtnYesExit : BaseButton
{
    protected override void OnClick()
    {
        this.QuitGame();
    }
    protected virtual void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
