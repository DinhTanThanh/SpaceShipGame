using UnityEngine;

public class EnemyEnableByDistance : EnableByDistanceAbstract
{
    [SerializeField] protected MeteoriteController meteoriteController;
    public MeteoriteController MeteoriteController => meteoriteController;
    protected override void LoadComponent()
    {
        this.gameObjectBeFollow = GameObject.Find("Player");
        this.distanceLimit = 70f;
        this.meteoriteController=GetComponentInParent<MeteoriteController>();
        Debug.Log("Vo roi");
    }
    protected override void Reset()
    {
        LoadComponent();
    }
    protected override void Awake()
    {
        LoadComponent();
    }
    private void Update()
    {
        if (!IsDistanceAchiveLimit()) return;
        SpawnMeteorite.instance.GoBackList(transform.parent.gameObject);
        transform.parent.gameObject.SetActive(false);
        meteoriteController.MeoteoriteDamereceiver.ResetMonterState();
    }
}
