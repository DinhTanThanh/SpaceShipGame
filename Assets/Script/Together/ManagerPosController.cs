using System.Collections.Generic;
using UnityEngine;

public class ManagerPosController : LoadMonoBehaviour
{
    [SerializeField] protected List<Transform> listPosition=new List<Transform>();
    public List<Transform> ListPosition => listPosition;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.GetListPosition();
    }
    protected virtual void GetListPosition()
    {
        if (this.listPosition.Count > 0) return;
        foreach(Transform childPos in transform)
        {
            this.listPosition.Add(childPos);
        }
    }
    public virtual Transform GetPositionByName(string name)
    {
        Transform pos = null;
        foreach(Transform childPos in this.listPosition)
        {
            if (childPos.name.Contains(name))
            {
                pos = childPos;
            }
        }
        return pos;
    }
}
