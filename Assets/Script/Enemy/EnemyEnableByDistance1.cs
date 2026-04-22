using UnityEngine;

public class EnemyEnableByDistance1 : EnableByDistanceAbstract
{
    protected override void LoadComponent()
    {
        this.gameObjectBeFollow = GameObject.Find("Player");
        this.distanceLimit = 70f;
    }
    protected override void Reset()
    {
        LoadComponent();
    }
    protected override void Awake()
    {
        LoadComponent();
    }
    private void Update()
    {
        if (!IsDistanceAchiveLimit()) return;
        SpawnBulletEnemy.instance.GoBackList(transform.parent.gameObject);
        transform.parent.gameObject.SetActive(false);
    }
}
