using System;
using UnityEngine;
[Serializable]
public class GatewayStatus : MonoBehaviour
{
    [SerializeField] protected bool statusGateway = false;
    public bool StatusGetway => statusGateway;
    public void SetStatusGateway(bool statusGateway)
    {
        this.statusGateway = statusGateway;
    }
}
