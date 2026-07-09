using UnityEngine;

public class UILossGameController : LoadMonoBehaviour
{
    protected override void OnEnable()
    {
        base.OnEnable();
        SoundFX.Instance.PlayOneShotSoundFailedGame();
    }
}
