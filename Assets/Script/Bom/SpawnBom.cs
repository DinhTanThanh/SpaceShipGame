using UnityEngine;

public class SpawnBom : PoolPrefab
{
    private static SpawnBom instance;
    public static SpawnBom Instance => instance;
    [SerializeField] protected GameObject objectBome;
    public GameObject ObjectBome => objectBome;
    protected override void Awake()
    {
        base.Awake();
        SpawnBom.instance = this;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBome();
    }
    protected virtual void LoadBome()
    {
        if (this.objectBome != null) return;
        this.objectBome = GameObject.Find("Boom");
        Debug.LogWarning("Load Bom: " + transform.name);
    }
}
