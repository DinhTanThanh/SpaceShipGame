using UnityEngine;

public class EnemyExplosionLookatTarget : LookatObj
{
    [SerializeField] protected Transform player;
    public Transform Player => player;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayer();
        this.SetRotation(10f);
    }
    private void Update()
    {
        this.Direct(this.player.position);
    }
    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.Find("Player")?.transform;
        Debug.LogWarning("Load Player: " + transform.name);
    }
}
