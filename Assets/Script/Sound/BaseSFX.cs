using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class BaseSFX : LoadMonoBehaviour
{
    [SerializeField] protected AudioSource audioSource;
    public AudioSource AudioSource => audioSource;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAudioSource();
    }
    protected virtual void LoadAudioSource()
    {
        if (this.audioSource != null) return;
        this.audioSource = GetComponent<AudioSource>();
        Debug.LogWarning("Load AudioSource: " + transform.name);
    }
}
