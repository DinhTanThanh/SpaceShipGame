using UnityEngine;

public class LookatObjByShip : LookatObj
{
    [SerializeField] protected Transform playerShip;
    public Transform PlayerShip => playerShip;
    protected override void Reset()
    {
        base.Reset();
        SetRotation(0.6f);
    }
    protected override void LoadComponent()
    {
        this.playerShip = GameObject.Find("Player")?.transform;
    }
    private void Update()
    {
        if(this.playerShip == null) return;
        Direct(playerShip.position);
    }
}
