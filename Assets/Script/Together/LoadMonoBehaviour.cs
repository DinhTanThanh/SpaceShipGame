using UnityEngine;

public class LoadMonoBehaviour : MonoBehaviour
{
    protected virtual void LoadComponent() { }
    protected virtual void LoadComponentEnable() { }
    protected virtual void LoadComponentStart() { }
    protected virtual void Awake()
    {
        this.LoadComponent();
    }
    protected virtual void Reset()
    {
        this.LoadComponent();
    }
    protected virtual void Start()
    {
        this.LoadComponentStart();
    }
    protected virtual void OnEnable()
    {
        this.LoadComponentEnable();
    }
}
