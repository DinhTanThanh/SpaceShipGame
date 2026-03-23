using UnityEngine;

public abstract class EnableByDistanceAbstract : MonoBehaviour
{
    [SerializeField] protected float distanceLimit;
    [SerializeField] protected float distanceNow;
    public float DistanceNow=>distanceNow;
    [SerializeField] protected GameObject gameObjectBeFollow;
    public GameObject GameOBjectBeFollow => gameObjectBeFollow;
    protected abstract void LoadComponet();
    protected virtual void Reset()
    {
        LoadComponet();
    }
    protected virtual void Awake()
    {
        LoadComponet();
    }
    public bool IsDistanceAchiveLimit()
    {
        distanceNow = Vector3.Distance(transform.position, GameOBjectBeFollow.transform.position);
        if (DistanceNow < distanceLimit) return false;
        return true;
    }
}
