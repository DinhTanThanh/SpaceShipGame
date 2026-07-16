using System.Collections.Generic;
using UnityEngine;

public class ChipiNoticeController : BaseChipi
{
    [SerializeField] protected Transform positionNotice;
    [SerializeField] protected GameObject uiNotice;
    [SerializeField] protected ChipiMoving chipiMoving;
    [SerializeField] protected List<GameObject> listUINotice=new List<GameObject>();
    public GameObject UINotice => uiNotice;
    public Transform PositionNotice => positionNotice;
    public ChipiMoving ChipiMoving => chipiMoving;
    public List<GameObject> ListUINotice => listUINotice;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPositionNotice();
        this.LoadUINotice();
        this.GetListUINotice();
        this.LoadChipiMoving();
    }
    protected virtual void LoadChipiMoving()
    {
        if (this.chipiMoving != null) return;
        this.chipiMoving=GetComponentInChildren<ChipiMoving>();
        Debug.LogWarning("Load ChipiMoving: " + transform.name);
    }
    protected virtual void GetListUINotice()
    {
        if (this.uiNotice == null) return;
        if (this.listUINotice.Count > 0) return;
        foreach(Transform child in this.uiNotice.transform)
        {
            this.listUINotice.Add(child.gameObject);
        }
    }
    protected virtual void LoadUINotice()
    {
        if (this.uiNotice != null) return;
        this.uiNotice = GameObject.Find("UINotice");
        Debug.LogWarning("Load UINotice: " + transform.name);
    }
    protected virtual void LoadPositionNotice()
    {
        if (this.positionNotice != null) return;
        this.positionNotice = transform.Find("Position");
        Debug.LogWarning("Load Position: " + transform.name);
    }
    public virtual GameObject GetUINoticeByName(string nameNotice)
    {
        foreach(GameObject uiNotice in this.listUINotice)
        {
            if(uiNotice.name.CompareTo(nameNotice)==0) return uiNotice;
        }
        return null;
    }
}
