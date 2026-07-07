using UnityEngine;

public class EnemySupportController : ShootingController
{
    [SerializeField] protected AbilityLookatTarget abilityLookatTarget;
    [SerializeField] protected EnemySupportDameReceiver enemySupportDameReceiver;
    [SerializeField] protected GameObject bossFinal;
    public EnemySupportDameReceiver EnemySupportDameReceiver => enemySupportDameReceiver;
    private void Update()
    {
        if (this.bossFinal.activeSelf) return;
        this.gameObject.SetActive(false);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySO();
        this.LoadEnemySupportDameReceiver();
        this.LoadAbilityLookatTarget();
        this.LoadBossFinal();
    }
    protected virtual void LoadBossFinal()
    {
        if (this.bossFinal != null) return;
        this.bossFinal = GameObject.Find("BossFinal");
        Debug.LogWarning("Load BossFinal: " + transform.name);
    }
    protected virtual void LoadAbilityLookatTarget()
    {
        if (this.abilityLookatTarget != null) return;
        this.abilityLookatTarget = GetComponentInChildren<AbilityLookatTarget>();
        this.abilityLookatTarget.SetRotation(10f);
        Debug.LogWarning("Load AbilityLookatTarget: " + transform.name);
    }
    protected virtual void LoadEnemySupportDameReceiver()
    {
        if (this.enemySupportDameReceiver != null) return;
        this.enemySupportDameReceiver = GetComponentInChildren<EnemySupportDameReceiver>();
        Debug.LogWarning("Load EnemySupportDameReceiver: " + transform.name);
    }
    public override void LoadEnemySO()
    {
        if (this.shootingSO != null) return;
        string path = "Shooting/Enemy/" + transform.name;
        this.shootingSO = Resources.Load<ShootingSO>(path);
        Debug.LogWarning("Load EnemySO: " + transform.name);
    }
}
