using UnityEngine;

public class ItemFollowShip : MonoBehaviour
{
    public Transform Camera;
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
        FollowCameraa();
    }
    public void LoadComponent()
    {
        if (Camera != null) return;
        Camera = GameObject.Find("Camera").transform;
    }
    public void FollowCameraa()
    {
        transform.position = Camera.position;
    }
    
}
