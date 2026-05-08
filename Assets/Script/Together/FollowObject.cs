using UnityEngine;

public abstract class FollowObject : LoadMonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    public GameObject ObjectPrefab => objectPrefab;
    public string nameObject = "";
    public float order = -10f;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.SetNameObject();
        this.LoadObjectPrefab();
    }
    protected virtual void LoadObjectPrefab()
    {
        if (this.objectPrefab != null) return;
        this.objectPrefab = GameObject.Find(nameObject);
        Debug.LogWarning("Load FollowObject: " + transform.name);
    }
    public void Update()
    {
        Moving();
    }
    public void Moving()
    {
        Vector3 posObject = ObjectPrefab.transform.position;
        Vector3 posPrecent = transform.parent.position;
        Vector3 newPosPrecent = Vector3.Lerp(posPrecent, posObject, 0.2f * Time.deltaTime);
        newPosPrecent.z = order;
        transform.parent.position = newPosPrecent;
    }
    public abstract void SetNameObject();
}
