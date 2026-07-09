using UnityEngine;
using UnityEngine.Rendering;

public class SoundFX : LoadMonoBehaviour
{
    private static SoundFX instance;
    public static SoundFX Instance => instance;
    [SerializeField] protected SoundClick soundClick;
    [SerializeField] protected SoundLoot soundLoot;
    [SerializeField] protected SoundShipShoot soundShipShoot;
    [SerializeField] protected SoundSmallExplosion soundSmallExplosion;
    [SerializeField] protected SoundShoot soundShoot;
    [SerializeField] protected SoundShootLaze soundShootLaze;
    [SerializeField] protected SoundImpact soundImpact;
    [SerializeField] protected SoundImpact_2 soundImpact_2;
    [SerializeField] protected SoundBigExplosion soundBigExplosion;
    [SerializeField] protected SoundBoomExplosion soundBoomExplosion;
    [SerializeField] protected SoundElectric soundElectric;
    [SerializeField] protected SoundTonado soundTonado;
    [SerializeField] protected SoundCompleteGame soundCompleteGame;
    [SerializeField] protected SoundFailedGame soundFailedGame;
    protected override void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SoundFX.instance = this;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSoundClick();
        this.LoadSoundLoot();
        this.LoadSoundShipShoot();
        this.LoadSoundSmallExplosion();
        this.LoadSoundShoot();
        this.LoadSoundShootLaze();
        this.LoadSoundImpact();
        this.LoadSoundImpact_2();
        this.LoadSoundBigExplosion();
        this.LoadSoundBoomExplosion();
        this.LoadSoundElectric();
        this.LoadSoundTonado();
        this.LoadSoundCompleteGame();
        this.LoadSoundFailedGame();
    }
    protected virtual void LoadSoundFailedGame()
    {
        if (this.soundFailedGame != null) return;
        this.soundFailedGame = GetComponentInChildren<SoundFailedGame>();
        Debug.LogWarning("Load SoundFailedGame: " + transform.name);
    }
    protected virtual void LoadSoundCompleteGame()
    {
        if (this.soundCompleteGame != null) return;
        this.soundCompleteGame = GetComponentInChildren<SoundCompleteGame>();
        Debug.LogWarning("Load SoundCompleteGame: " + transform.name);
    }
    protected virtual void LoadSoundTonado()
    {
        if (this.soundTonado != null) return;
        this.soundTonado=GetComponentInChildren<SoundTonado>();
        Debug.LogWarning("Load SoundTonado: " + transform.name);
    }
    protected virtual void LoadSoundElectric()
    {
        if (this.soundElectric != null) return;
        this.soundElectric = GetComponentInChildren<SoundElectric>();
        Debug.LogWarning("Load SoundElectric: " + transform.name);
    }
    protected virtual void LoadSoundBoomExplosion()
    {
        if (this.soundBoomExplosion != null) return;
        this.soundBoomExplosion = GetComponentInChildren<SoundBoomExplosion>();
        Debug.LogWarning("Load SoundBoomExplosion: " + transform.name);
    }
    protected virtual void LoadSoundBigExplosion()
    {
        if (this.soundBigExplosion != null) return;
        this.soundBigExplosion = GetComponentInChildren<SoundBigExplosion>();
        Debug.LogWarning("Load SoundBigExplosion: " + transform.name);
    }
    protected virtual void LoadSoundImpact()
    {
        if (this.soundImpact != null) return;
        this.soundImpact = GetComponentInChildren<SoundImpact>();
        Debug.LogWarning("Load SoundImpact: " + transform.name);
    }
    protected virtual void LoadSoundImpact_2()
    {
        if (this.soundImpact_2 != null) return;
        this.soundImpact_2 = GetComponentInChildren<SoundImpact_2>();
        Debug.LogWarning("Load SoundImpact_2: " + transform.name);
    }
    protected virtual void LoadSoundShootLaze()
    {
        if (this.soundShootLaze != null) return;
        this.soundShootLaze=GetComponentInChildren<SoundShootLaze>();
        Debug.LogWarning("Load SoundShootLaze: " + transform.name);
    }
    protected virtual void LoadSoundShoot()
    {
        if (this.soundShoot != null) return;
        this.soundShoot = GetComponentInChildren<SoundShoot>();
        Debug.LogWarning("Load SoundShoot: " + transform.name);
    }
    protected virtual void LoadSoundSmallExplosion()
    {
        if (this.soundSmallExplosion != null) return;
        this.soundSmallExplosion = GetComponentInChildren<SoundSmallExplosion>();
        Debug.LogWarning("Load SoundSmallExplosion: " + transform.name);
    }
    protected virtual void LoadSoundShipShoot()
    {
        if (this.soundShipShoot != null) return;
        this.soundShipShoot=GetComponentInChildren<SoundShipShoot>();
        Debug.LogWarning("Load SoundShipShoot: " + transform.name);
    }
    protected virtual void LoadSoundLoot()
    {
        if (this.soundLoot != null) return;
        this.soundLoot=GetComponentInChildren<SoundLoot>();
        Debug.LogWarning("Load SoundLoot: " + transform.name);
    }
    protected virtual void LoadSoundClick()
    {
        if (this.soundClick != null) return;
        this.soundClick=GetComponentInChildren<SoundClick>();
        Debug.LogWarning("Load SoundClick: " + transform.name);
    }
    public virtual GameObject GetChildObjectByName(string nameChild)
    {
        return this.transform.Find(nameChild).gameObject;
    }
    public virtual void PlayOneShotSoundClick()
    {
        if (this.soundClick == null) return;
        AudioClip audioClip = this.soundClick.AudioSource.clip;
        this.soundClick.AudioSource.PlayOneShot(audioClip);
    }
    public virtual void PlayOneShotSoundLoot()
    {
        if (this.soundLoot == null) return;
        AudioClip audioClip = this.soundLoot.AudioSource.clip;
        this.soundLoot.AudioSource.PlayOneShot(audioClip);
    }
    public virtual void PlayOneShotSoundShipShoot()
    {
        if (this.soundShipShoot == null) return;
        AudioClip audioClip = this.soundShipShoot.AudioSource.clip;
        this.soundShipShoot.AudioSource.PlayOneShot(audioClip);
    }
    public virtual void PlayOneShotSoundSmallExplosion()
    {
        if (this.soundSmallExplosion == null) return;
        AudioClip audioClip = this.soundSmallExplosion.AudioSource.clip;
        this.soundSmallExplosion.AudioSource.PlayOneShot(audioClip);
    }
    public virtual void PlayOneShotSoundShoot()
    {
        if (this.soundShoot == null) return;
        AudioClip audioClip = this.soundShoot.AudioSource.clip;
        this.soundShoot.AudioSource.PlayOneShot(audioClip);
    }
    public virtual void PlayOneShotSoundShootLaze()
    {
        if (this.soundShootLaze == null) return;
        AudioClip audioClip = this.soundShootLaze.AudioSource.clip;
        this.soundShootLaze.AudioSource.PlayOneShot(audioClip);
    }
    public virtual void PlayOneShotSoundImpact()
    {
        if (this.soundImpact == null) return;
        AudioClip audioClip = this.soundImpact.AudioSource.clip;
        this.soundImpact.AudioSource.PlayOneShot(audioClip);
    }
    public virtual void PlayOneShotSoundImpact_2()
    {
        if (this.soundImpact_2 == null) return;
        AudioClip audioClip = this.soundImpact_2.AudioSource.clip;
        this.soundImpact_2.AudioSource.PlayOneShot(audioClip);
    }
    public virtual void PlayOneShotSoundBigExplosion()
    {
        if (this.soundBigExplosion == null) return;
        AudioClip audioClip = this.soundBigExplosion.AudioSource.clip;
        this.soundBigExplosion.AudioSource.PlayOneShot(audioClip);
    }
    public virtual void PlayOneShotSoundBoomExplosion()
    {
        if (this.soundBoomExplosion == null) return;
        AudioClip audioClip = this.soundBoomExplosion.AudioSource.clip;
        this.soundBoomExplosion.AudioSource.PlayOneShot(audioClip);
    }
    public virtual void PlayOneShotSoundElectric()
    {
        if (this.soundElectric == null) return;
        AudioClip audioClip = this.soundElectric.AudioSource.clip;
        this.soundElectric.AudioSource.PlayOneShot(audioClip);
    }
    public virtual void PlayOneShotSoundTonado()
    {
        if (this.soundTonado == null) return;
        AudioClip audioClip = this.soundTonado.AudioSource.clip;
        this.soundTonado.AudioSource.PlayOneShot(audioClip);
    }
    public virtual void PlayOneShotSoundCompleteGame()
    {
        if (this.soundCompleteGame == null) return;
        AudioClip audioClip = this.soundCompleteGame.AudioSource.clip;
        this.soundCompleteGame.AudioSource.PlayOneShot(audioClip);
    }
    public virtual void PlayOneShotSoundFailedGame()
    {
        if (this.soundFailedGame == null) return;
        AudioClip audioClip = this.soundFailedGame.AudioSource.clip;
        this.soundFailedGame.AudioSource.PlayOneShot(audioClip);
    }
}
