using UnityEngine;

public class AbilityLookatTarget :LookatObj
{
    [SerializeField] protected Transform target;
    public Transform Target=>target;
    protected override void Reset()
    {
        base.Reset();
        this.speedRotation = 0.5f;
    }
    protected override void LoadComponent()
    {
        this.target = GameObject.Find("Player")?.transform;
    }
    private void Update()
    {
        if (this.target == null) return;
        Direct(target.position);
    }
}
