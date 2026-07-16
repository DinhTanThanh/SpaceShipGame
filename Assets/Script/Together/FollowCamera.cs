using UnityEngine;

public class Follow : LoadMonoBehaviour
{
    public GameObject objectFollow;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayer();
    }
    protected virtual void LoadPlayer()
    {
        if (this.objectFollow != null) return;
        this.objectFollow = GameObject.Find("Player");
        Debug.LogWarning("Load Player: " + transform.name);
    }
    private void Update()
    {
        this.transform.position=this.objectFollow.transform.position;
        //this.transform.rotation=this.objectFollow.transform.rotation;
    }
}
