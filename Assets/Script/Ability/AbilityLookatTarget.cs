using UnityEngine;

public class AbilityLookatTarget :LookatObj
{
    [SerializeField] protected Transform target;
    public Transform Target=>target;
    protected override void LoadComponent()
    {
        this.speedRotation = 1f;
        this.target = GameObject.Find("Player")?.transform;
    }
    private void Update()
    {
        if (this.target == null) return;
        Direct(target.position);
    }
    protected override void SetRotation()
    {
        this.speedRotation = 3f;
    }
}
