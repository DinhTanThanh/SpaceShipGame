using UnityEngine;

public class Follow : LoadMonoBehaviour
{
    public GameObject objectFollow;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCamera();
    }
    protected virtual void LoadCamera()
    {
        if (this.objectFollow != null) return;
        this.objectFollow = GameObject.Find("Camera");
        Debug.LogWarning("Load Camera: " + transform.name);
    }
    private void Update()
    {
        this.transform.position=this.objectFollow.transform.position;
        this.transform.rotation=this.objectFollow.transform.rotation;
    }
}
