using UnityEngine;

public class MusicController : LoadMonoBehaviour
{
    [SerializeField] protected MusicMainMenuBGM musicMainMenuBGM;
    public MusicMainMenuBGM MusicMainMenuBGM => musicMainMenuBGM;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMusicMainMenuBGM();
    }
    protected virtual void LoadMusicMainMenuBGM()
    {
        if (this.musicMainMenuBGM != null) return;
        this.musicMainMenuBGM=GetComponentInChildren<MusicMainMenuBGM>();
        Debug.LogWarning("Load MusicMainMenuBGM: " + transform.name);
    }
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
