using UnityEngine;

public class DameReceiver : LoadMonoBehaviour
{
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHp;
    public int Hp => hp;
    public int MaxHp => maxHp;
    [SerializeField] protected bool isDead;
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
    public virtual bool CheckIsDead()
    {
        if (this.hp <= 0) return true;
        return false;
    }
}
