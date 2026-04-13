using UnityEngine;

public abstract class EnableByDistanceAbstract : LoadMonoBehaviour
{
    [SerializeField] protected float distanceLimit;
    [SerializeField] protected float distanceNow;
    public float DistanceNow=>distanceNow;
    [SerializeField] protected GameObject gameObjectBeFollow;
    public GameObject GameOBjectBeFollow => gameObjectBeFollow;
    
    public bool IsDistanceAchiveLimit()
    {
        distanceNow = Vector3.Distance(transform.position, GameOBjectBeFollow.transform.position);
        if (DistanceNow < distanceLimit) return false;
        return true;
    }
}
