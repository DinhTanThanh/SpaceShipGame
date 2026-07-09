using UnityEngine;

public abstract class BaseLevel : LoadMonoBehaviour
{
    [SerializeField] protected ShootingController shootingController;
    public abstract ShootingController GetBossLevel();
    public abstract void RebornLevel();
}
