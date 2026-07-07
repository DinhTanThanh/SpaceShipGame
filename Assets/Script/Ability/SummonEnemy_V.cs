using UnityEngine;

public class SummonEnemy_V : LoadMonoBehaviour
{
    [SerializeField] protected GameObject enemy_v2;
    [SerializeField] protected GameObject enemy_v3;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemy_v2();
        this.LoadEnemy_v3();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.enemy_v2.SetActive(true);
        this.enemy_v3.SetActive(true);
    }
    protected virtual void LoadEnemy_v2()
    {
        if (this.enemy_v2 != null) return;
        this.enemy_v2 = GameObject.Find("Enemy_v2");
        Debug.LogWarning("Load Enemy_v2: " + transform.name);
    }
    protected virtual void LoadEnemy_v3()
    {
        if(this.enemy_v3 != null) return;
        this.enemy_v3 = GameObject.Find("Enemy_v3");
        Debug.LogWarning("Load Enemy_v3: " + transform.name);
    }
}
