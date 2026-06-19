using UnityEngine;

public abstract class FollowObject : LoadMonoBehaviour
{
    [SerializeField] protected float speed = 0.2f;
    protected string nameObject = "";
    protected float order = -10f;
    [SerializeField] protected GameObject objectTarget;
    public GameObject ObjectTarget => objectTarget;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.SetNameObject();
        this.LoadObjectPrefab();
    }
    protected virtual void LoadObjectPrefab()
    {
        if (this.objectTarget != null) return;
        this.objectTarget = GameObject.Find(this.nameObject);
        Debug.LogWarning("Load FollowObject: " + transform.name);
    }
    public void Update()
    {
        this.Moving();
    }
    protected virtual void Moving()
    {
        Vector3 posObject = this.ObjectTarget.transform.position;
        Vector3 posPrecent = transform.parent.position;
        Vector3 newPosPrecent = Vector3.Lerp(posPrecent, posObject, this.speed * Time.deltaTime);
        newPosPrecent.z = order;
        transform.parent.position = newPosPrecent;
    }
    public abstract void SetNameObject();
    public virtual void SetSpeed(float speed)
    {
        this.speed= speed;
    }
}
