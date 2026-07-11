using UnityEngine;

public class SoundImpact : BaseSFX
{
    protected override void Awake()
    {
        base.Awake();
        this.audioSource.volume = 0.5f;
    }
}
