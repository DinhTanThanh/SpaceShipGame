using UnityEngine;

public class LoadMonoBehaviour : MonoBehaviour
{
    protected virtual void LoadComponent()
    {
        //override and do anything
    }
    protected virtual void LoadComponentEnable() 
    {
        //override and do anything
    }
    protected virtual void LoadComponentStart()
    {
        //override and do anything
    }
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
