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
        FollowShip();
    }
    public void LoadComponent()
    {
        if (Camera != null) return;
        Camera = GameObject.Find("Camera").transform;
    }
    public void FollowShip()
    {
        transform.position = Camera.position;
    }
    
}
