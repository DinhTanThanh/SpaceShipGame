using UnityEngine;

public class MusicMainMenuBGM : BaseMusic
{
    public virtual void TurnDownSound(float volume)
    {
        this.audioSource.volume = volume;
    }
}
