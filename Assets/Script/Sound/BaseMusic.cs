using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class BaseMusic : LoadMonoBehaviour
{
    [SerializeField] protected AudioSource audioSource;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAudioSource();
    }
    protected virtual void LoadAudioSource()
    {
        if (this.audioSource != null) return;
        this.audioSource=GetComponent<AudioSource>();
        Debug.LogWarning("Load AudioSource: " + transform.name);
    }
    protected override void Start()
    {
        base.Start();
        this.audioSource.loop = true;
        this.audioSource.Play();
    }
}
