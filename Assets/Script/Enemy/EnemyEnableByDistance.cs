using UnityEngine;

public class EnemyEnableByDistance : EnableByDistanceAbstract
{
    [SerializeField] protected MeteoriteController meteoriteController;
    public MeteoriteController MeteoriteController => meteoriteController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCamera();
        this.distanceLimit = 70f;
        this.LoadMeteoriteController();
    }
    protected virtual void LoadMeteoriteController()
    {
        if (this.meteoriteController != null) return;
        this.meteoriteController=GetComponentInParent<MeteoriteController>();
        Debug.LogWarning("Load MeteoriteController: " + transform.name);
    }
    protected virtual void LoadCamera()
    {
        if (this.gameObjectBeFollow != null) return;
        this.gameObjectBeFollow = GameObject.Find("Camera");
        Debug.LogWarning("Load Camera: " + transform.name);
    }
    private void Update()
    {
        if (!IsDistanceAchiveLimit()) return;
        this.meteoriteController.DameReceiver.IsDead = true;
    }
}
