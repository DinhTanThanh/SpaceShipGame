using UnityEngine;

public class DameReceiver : LoadMonoBehaviour
{
    [SerializeField] private int hp;
    public int HP
    {
        get { return hp; }
        set { hp = value; }
    }
    [SerializeField] private bool isDead;
    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }
    }
    public virtual void Reborn()
    {
        this.HP = 1;
        this.IsDead = false;
    }
    public virtual void AddHP(int addHP)
    {
        this.HP += addHP;
    }
    public virtual void Receiver(int hp)
    {
        this.HP-= hp;
    }

}
