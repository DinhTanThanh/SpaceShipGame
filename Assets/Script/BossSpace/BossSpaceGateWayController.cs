using System.Collections.Generic;
using UnityEngine;

public class BossSpaceGateWayController : LoadMonoBehaviour
{
    [SerializeField] protected List<Transform> listGateway = new List<Transform>();
    public List<Transform> ListGateway => listGateway;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.GetListGateway();
    }
    protected virtual void GetListGateway()
    {
        if (this.listGateway.Count > 0) return;
        foreach(Transform gateway in transform)
        {
            this.listGateway.Add(gateway);
        }
    }
}
