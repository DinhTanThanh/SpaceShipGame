using UnityEngine;

public class ThunderDameSender : DameSender
{
    [SerializeField] protected GameObject spawnImpact;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnImpact();
    }
    protected virtual void LoadSpawnImpact()
    {
        if (this.spawnImpact != null) return;
        this.spawnImpact = GameObject.Find("SpawnImpact");
        Debug.LogWarning("Load SpawnImpact: " + transform.name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DameReceiver dameReceiver = collision.transform.parent?.parent?.GetComponentInChildren<DameReceiver>();
        if (dameReceiver != null && (dameReceiver as PlayerDameReceiver ||dameReceiver as SupportShipDameReceiver))
        {
            ExecuteReceiver(dameReceiver,100);
            //Làm va chạm của ship và thunder khác đi (cho nó đẹp)
            Vector3 newPos = transform.position;
            newPos.z = -5f;
            SpawnImpact.instance.SetPosition(SpawnImpact.instance.Impact, newPos, transform.rotation).transform.SetParent(this.spawnImpact.transform);
        }
    }
}
