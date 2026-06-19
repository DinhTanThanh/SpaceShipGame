using UnityEngine;

public class LookatObjByShip : LookatObj
{
    [SerializeField] protected Transform playerShip;
    public Transform PlayerShip => playerShip;
    protected override void Reset()
    {
        base.Reset();
        SetRotation();
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
    protected override void SetRotation()
    {
        this.speedRotation = 0.6f;
    }
}
