using UnityEngine;

public class SoundLoot : BaseSFX
{
    protected override void Awake()
    {
        base.Awake();
        this.audioSource.volume = 0.38f;
    }
}
