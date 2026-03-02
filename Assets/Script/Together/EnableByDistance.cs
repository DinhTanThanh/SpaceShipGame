using UnityEngine;

public class EnableByDistance : MonoBehaviour
{
    public GameObject mainCamera;
    private void Reset()
    {
        mainCamera = GameObject.Find("Main Camera");
    }
    private void Awake()
    {
        mainCamera = GameObject.Find("Main Camera");
    }
    private void Update()
    {
        if (Distance() > 20f)
        {
            SpawnBullet.instance.GoBackList(gameObject);
            gameObject.SetActive(false);
        }
    }
    public float Distance()
    {
        float dis=Vector3.Distance(transform.position,mainCamera.transform.position);
        return dis; 
    }
}
