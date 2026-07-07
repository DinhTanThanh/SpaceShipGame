using UnityEngine;

public class FollowTarget : LoadMonoBehaviour
{
    [SerializeField] protected Transform target;
    public Transform Target => target;
    [SerializeField] protected RectTransform objPrefab;
    public RectTransform ObjPrefab => objPrefab;
    [SerializeField] float speed = 20;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadObjPrefab();
    }
    protected virtual void LoadObjPrefab()
    {
        this.objPrefab = GetComponent<RectTransform>();
    }
    protected virtual void SetSpeed(float speed)
    {
        this.speed = speed; 
    }
    private void FixedUpdate()
    {
        if (!this.target.gameObject.activeSelf)
        {
            this.transform.gameObject.SetActive(false);
        }
        this.LerpTarget();
    }
    protected virtual void LerpTarget()
    {
        Vector3 posTarget = target.position;
        Vector3 postObjPrefab = objPrefab.position;
        this.objPrefab.position = Vector3.Lerp(postObjPrefab, posTarget, Time.deltaTime * speed);
    }
    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
}
