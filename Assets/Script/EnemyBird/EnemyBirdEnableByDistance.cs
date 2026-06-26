using UnityEngine;

public class EnemyBirdEnableByDistance : EnableByDistanceAbstract
{
    [SerializeField] protected EnemyBirdController enemyBirdController;
    public EnemyBirdController EnemyBirdController => enemyBirdController;
    protected override void LoadComponent()
    {
        this.LoadObjetBeFollow();
        this.distanceLimit = 70f;
        this.LoadEnemyBirdController();
    }
    protected virtual void LoadEnemyBirdController()
    {
        if (this.enemyBirdController != null) return;
        this.enemyBirdController = GetComponentInParent<EnemyBirdController>();
        Debug.LogWarning("Load EnemyBirdController: " + transform.name);
    }
    protected virtual void LoadObjetBeFollow()
    {
        if (this.gameObjectBeFollow != null) return;
        this.gameObjectBeFollow = GameObject.Find("Camera");
        Debug.LogWarning("Load ObjetBeFollow: " + transform.name);
    }
    private void Update()
    {
        if (!IsDistanceAchiveLimit()) return;
        this.enemyBirdController.DameReceiver.IsDead = true;
        //SpawnEnemyBird.Instance.GoBackList(transform.parent.gameObject);
        //this.transform.parent.gameObject.SetActive(false);
    }
}
