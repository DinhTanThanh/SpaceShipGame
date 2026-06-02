using UnityEngine;

public class SpawnItemVitalityUp : PoolPrefab
{
    private static SpawnItemVitalityUp instance;
    public static SpawnItemVitalityUp Instance => instance;
    [SerializeField] protected GameObject itemVitalityUp;
    public GameObject ItemVitalityUp => itemVitalityUp;
    protected override void Awake()
    {
        base.Awake();
        SpawnItemVitalityUp.instance= this; 
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemVitalityUp();
    }
    protected virtual void LoadItemVitalityUp()
    {
        if (this.itemVitalityUp != null)
        {
            this.itemVitalityUp.SetActive(false);
            return;
        }
        this.itemVitalityUp = GameObject.Find("ItemVitalityUp");
        
        Debug.LogWarning("Load ItemVatilityUp: "+transform.name);
    }
}
