using System.Collections.Generic;
using UnityEngine;

public class BaseChipi : LoadMonoBehaviour
{
    [SerializeField] protected Transform managerPosNotice;
    [SerializeField] protected List<Transform> listPosNotice = new List<Transform>();
    public List<Transform> ListPosNotice => listPosNotice;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadManagerPosNotice();
        this.GetListPosNotice();
    }
    protected virtual void LoadManagerPosNotice()
    {
        if (this.managerPosNotice != null) return;
        this.managerPosNotice = GameObject.Find("ManagerPosNotice")?.transform;
        Debug.LogWarning("Load ManagerPosNotice: " + transform.name);
    }
    protected virtual void GetListPosNotice()
    {
        if (this.managerPosNotice == null) return;
        if (this.listPosNotice.Count > 0) return;
        foreach (Transform posNotice in this.managerPosNotice)
        {
            this.listPosNotice.Add(posNotice);
        }
    }
}
