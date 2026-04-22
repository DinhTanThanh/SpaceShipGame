using UnityEngine;

public class EnemySpawnController : LoadMonoBehaviour
{
    [SerializeField] protected GameObject managerPlayer;
    public GameObject ManagerPlayer=>managerPlayer;
    protected override void LoadComponent()
    {
        this.managerPlayer = GameObject.Find("ManagerPlayer");
    }
}
