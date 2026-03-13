using UnityEngine;

public class MovingPlayer : MonoBehaviour
{
    public float speedShip = 0.005f;
    private void Update()
    {
        Moving();
    }
    public void Moving()
    {
        Vector3 positionShip=transform.parent.position;
        Vector3 newPosition= Vector3.Lerp(transform.parent.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), speedShip);
        newPosition.z = 0f;
        transform.parent.position = newPosition;
        Direct();
    }
    public void Direct()
    {
        Vector3 posShip=transform.parent.position;
        Vector3 posCamera=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newPos = posCamera - posShip;
        float dir = Mathf.Atan2(newPos.y, newPos.x)*Mathf.Rad2Deg;
        transform.parent.rotation=Quaternion.Euler(0,0,dir-90);
    }
}
