using UnityEngine;

public class SnakeCamera : LoadMonoBehaviour
{
    [SerializeField] protected Transform mainCamera;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMainCamera();
    }
    protected virtual void LoadMainCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = transform.Find("Main Camera");
        Debug.LogWarning("Load Main Camera: " + transform.name);
    }

}
