using UnityEngine;

public class ShipMoving : LoadComponentGame
{
    [SerializeField] protected GameObject shipController;
    public GameObject ShipController => shipController;
    private void Reset()
    {
        LoadComponent();
    }
    private void Awake()
    {
        LoadComponent();
    }
    private void Update()
    {
        Moving();
    }
    public override void LoadComponent()
    {
        if (shipController == null)
        {
            this.shipController = GameObject.Find("Ship");
        }
    }
    protected void Moving()
    {
        //dùng nội suy tuyến tính của thằng unity
        Vector3 newPosition = Vector3.Lerp(shipController.transform.position, ManagerController.Instance.InputController.PositionPoint.PositionPoint, Time.deltaTime * 3f);
        newPosition.z = 10f;
        Direct();
        shipController.transform.position = newPosition;
    }
    protected void Direct()
    {
        Vector3 positionShip = shipController.transform.position;
        Vector3 positionPoint = ManagerController.Instance.InputController.PositionPoint.PositionPoint;
        Vector3 newPosition = positionPoint - positionShip;
        //newPosition.Normalize();
        float dir = Mathf.Atan2(newPosition.y, newPosition.x)*Mathf.Rad2Deg;
        shipController.transform.rotation = Quaternion.Euler(0, 0, dir-90);
    }
}
