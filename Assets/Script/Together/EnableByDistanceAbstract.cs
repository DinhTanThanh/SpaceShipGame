using UnityEngine;

public abstract class EnableByDistanceAbstract : LoadMonoBehaviour
{
    [SerializeField] protected float distanceLimit;
    [SerializeField] protected float distanceNow;
    public float DistanceNow=>distanceNow;
    [SerializeField] protected GameObject gameObjectBeFollow;
    public GameObject GameObjectBeFollow => gameObjectBeFollow;
    
    public bool IsDistanceAchiveLimit()
    {
        this.distanceNow = Vector3.Distance(this.transform.parent.position, this.GameObjectBeFollow.transform.position);
        if (this.distanceNow < this.distanceLimit) return false;
        return true;
    }
}
