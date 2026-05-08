using UnityEngine;

public class SliderChangeHp : BaseSlider
{
    [SerializeField] protected int currentHp = 1;
    public int CurrentHp => currentHp;
    [SerializeField] protected int maxHp = 1;
    public int MaxHp=> maxHp;
    protected void FixedUpdate()
    {
        this.OnChangeSlider();
    }
    protected override void LoadComponentEnable()
    {
        base.LoadComponentEnable();
    }
    protected override void OnChangeSlider()
    {
        float percentHp = (float)this.currentHp / this.maxHp;
        this.slider.value = percentHp;
    }
    public virtual void SetCurrentHp(int currentHp)
    {
        this.currentHp = currentHp;
    }
    public virtual void SetMaxHp(int maxHp)
    {
        this.maxHp = maxHp;
    }
}
