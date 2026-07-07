using UnityEngine;

public class SummonEnemySupport : LoadMonoBehaviour
{
    [SerializeField] protected GameObject enemy_Support_1;
    [SerializeField] protected GameObject enemy_Support_2;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.enemy_Support_1.SetActive(true);
        this.enemy_Support_2.SetActive(true);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemy_Support_1();
        this.LoadEnemy_Support_2();
    }
    protected virtual void LoadEnemy_Support_1()
    {
        if (this.enemy_Support_1 != null) return;
        this.enemy_Support_1 = GameObject.Find("Enemy_Support_1");
        Debug.LogWarning("Load Enemy_Support_1: " + transform.name);
    }
    protected virtual void LoadEnemy_Support_2()
    {
        if (this.enemy_Support_2 != null) return;
        this.enemy_Support_2 = GameObject.Find("Enemy_Support_2");
        Debug.LogWarning("Load Enemy_Support_2: " + transform.name);
    }
}
