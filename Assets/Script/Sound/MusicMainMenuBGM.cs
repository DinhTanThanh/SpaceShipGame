using UnityEngine;

public class MusicMainMenuBGM : BaseMusic
{
    public virtual void TurnDownSound()
    {
        this.audioSource.volume = 0.4f;
    }
}
