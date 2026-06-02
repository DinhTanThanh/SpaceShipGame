using UnityEngine;

public class SupportShipLookatTarget : LookatObj
{
    [SerializeField] protected Transform player;
    public Transform Player => player;
    protected override void LoadComponent()
    {
        SetRotation();
        this.player = GameObject.Find("Player")?.transform;
    }
    private void Update()
    {
        if (this.player == null) return;
        Direct(player.position);
    }
    protected override void SetRotation()
    {
        this.speedRotation = 10f;
    }
}
