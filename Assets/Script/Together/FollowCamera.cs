using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject mainCamera;
    private void Reset()
    {
        mainCamera = GameObject.Find("Camera");
    }
    private void Awake()
    {
        mainCamera = GameObject.Find("Camera");
    }
    private void Update()
    {
        transform.position=mainCamera.transform.position;
    }
}
