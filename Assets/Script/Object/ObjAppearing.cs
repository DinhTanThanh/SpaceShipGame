using UnityEngine;

public abstract class ObjAppearing : LoadMonoBehaviour
{
    [Header("ObjAppearing")]
    [SerializeField] protected bool isAppeared = false;
    protected abstract void Appearing();
    protected virtual void IsAppeared()
    {
        this.isAppeared = true;
    }
}
