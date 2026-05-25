using Unity.Jobs;
using UnityEngine;

public class AwakeMotherShip : LoadMonoBehaviour
{
    [SerializeField] protected GameObject motherShip;
    public GameObject MotherShip => motherShip;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMotherShip();
    }
    protected override void Awake()
    {
        base.Awake();
        this.motherShip.SetActive(true);
    }
    protected virtual void LoadMotherShip()
    {
        if (this.motherShip != null) return;
        this.motherShip = GameObject.Find("MotherShip_1");
        this.motherShip.SetActive(false);
        Debug.LogWarning("Load MotherShip: " + transform.name);
    }
}
