using UnityEngine;

public class Follow : MonoBehaviour
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
        transform.position=mainCamera.transform.position;
    }
}
