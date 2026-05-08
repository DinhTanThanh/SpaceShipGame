using UnityEngine;

public class SpawnHpBar : PoolPrefab
{
    [SerializeField] protected GameObject hpBar;
    public GameObject HpBar => hpBar;
    [SerializeField] protected static SpawnHpBar instance;
    public static SpawnHpBar Instance => instance;
    protected override void Awake()
    {
        base.Awake();
        SpawnHpBar.instance = this;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHpBar();
    }
    protected virtual void LoadHpBar()
    {
        if (this.hpBar != null) return;
        this.hpBar = GameObject.Find("HpBar");
    }
}
