using UnityEngine;

public class HpBar : LoadMonoBehaviour
{
    [SerializeField] protected ShootingController shootingController;
    public ShootingController ShottingController => shootingController;
    [SerializeField] protected SliderChangeHp sliderChangeHp;
    public SliderChangeHp SliderChangeHp => sliderChangeHp;
    [SerializeField] protected FollowTarget followTarget;
    public FollowTarget FollowTarget => followTarget;
    [SerializeField] protected bool isDead=false;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSliderChangeHp();
        this.LoadFollowTarget();
    }
    protected virtual void FixedUpdate()
    {
        this.CheckTargetIsDead();
        this.ChangeHpBar();
    }
    protected virtual void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = GetComponent<FollowTarget>();
        Debug.LogWarning("Load FollowTarget: " + transform.name);
    }
    protected virtual void LoadSliderChangeHp()
    {
        if (this.sliderChangeHp != null) return;
        this.sliderChangeHp = GetComponentInChildren<SliderChangeHp>();
        Debug.LogWarning("Load SliderChangeHp: " + transform.name);
    }
    protected virtual void ChangeHpBar()
    {
        if (this.shootingController == null) return;
        int currentHp = this.shootingController.DameReceiver.Hp;
        int maxHp = this.shootingController.DameReceiver.MaxHp;

        this.sliderChangeHp.SetCurrentHp(currentHp);
        this.sliderChangeHp.SetMaxHp(maxHp);
    }
    public virtual void SetShootingController(ShootingController shootingController)
    {
        this.shootingController = shootingController;
    }
    protected virtual void CheckTargetIsDead()
    {
        this.isDead = this.shootingController.DameReceiver.IsDead;
        if (!this.isDead) return;
        this.gameObject.SetActive(false);
        SpawnHpBar.Instance.GoBackList(this.gameObject);
    }
}
