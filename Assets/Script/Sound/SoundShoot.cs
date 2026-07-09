using UnityEngine;

public class SoundShoot : BaseSFX
{
    protected override void Awake()
    {
        base.Awake();
        this.audioSource.volume = 0.4f;
    }
}
