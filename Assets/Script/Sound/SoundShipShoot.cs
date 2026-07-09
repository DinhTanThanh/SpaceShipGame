using UnityEngine;

public class SoundShipShoot : BaseSFX
{
    protected override void Awake()
    {
        base.Awake();
        this.audioSource.volume = 0.3f;
    }
    public virtual void SetVolume(float volume)
    {
        this.audioSource.volume = volume;
    }
}
