using UnityEngine;

public class Follow : LoadMonoBehaviour
{
    public GameObject objectFollow;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        objectFollow = GameObject.Find("Camera");
    }
    private void Update()
    {
        transform.position=objectFollow.transform.position;
        transform.rotation=objectFollow.transform.rotation;
    }
}
