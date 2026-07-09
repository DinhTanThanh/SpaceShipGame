using UnityEngine;

public class TonadoController : LoadMonoBehaviour
{
    protected override void OnEnable()
    {
        base.OnEnable();
        SoundFX.Instance.PlayOneShotSoundTonado();
    }
}
