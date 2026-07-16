using UnityEngine;

public class DameReceiver : LoadMonoBehaviour
{
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHp;
    [SerializeField] protected int ki;
    [SerializeField] protected int maxKI;
    [SerializeField] protected bool isDead;
    public int Hp => hp;
    public int MaxHp => maxHp;
    public int KI => ki;
    public int MaxKI => maxKI;
    public bool IsDead
    {
        get { return this.isDead; }
        set { this.isDead = value; }
    }
    public virtual void Reborn()
    {
        this.hp = 1;
        this.maxHp = 1;
        this.IsDead = false;
    }
    public virtual void AddHP(int addHp)
    {
        this.hp += addHp;
    }
    public virtual void AddMaxHP(int addMaxHP)
    {
        this.maxHp += addMaxHP;
    }
    public virtual void Receive(int dame)
    {
        this.hp-= dame;
    }
    public virtual void ConsumeKi(int ki)
    {
        this.ki -= ki;
    }
    public virtual bool HasEnoughKi()
    {
        if (this.ki <= 0) return false;
        return true;
    }
    public virtual void RecoveryKi(int ki)
    {
        int newKi = this.ki + ki;
        if (newKi >= this.maxKI)
        {
            if (this.ki >= this.maxKI) return;
            this.ki = this.maxKI;
            return;
        }
        this.ki +=ki;
    }
    public virtual bool CheckIsDead()
    {
        if (this.hp <= 0) return true;
        return false;
    }
    public virtual void ResetKi(int ki)
    {
        this.ki = ki;
    }
    public virtual void SetMaxHpAndHp(int hp, int maxHp)
    {
        this.hp = hp;
        this.maxHp = maxHp;
        this.isDead=false;
    }
}
