using UnityEngine;

public class AwakeBossSpace : LoadMonoBehaviour
{
    [SerializeField] protected GameObject bossSpace;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossSpace();
    }
    protected override void Awake()
    {
        base.Awake();
        this.bossSpace.gameObject.SetActive(true);
    }
    protected virtual void LoadBossSpace()
    {
        if (this.bossSpace != null) return;
        this.bossSpace = GameObject.Find("BossSpace");
        Debug.LogWarning("Load BossSpace: " + transform.name);
    }
}
