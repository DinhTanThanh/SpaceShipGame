using UnityEngine;

public class PlayerAbstract : MonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl=>playerCtrl;
    protected virtual void Reset()
    {
        LoadComponent();
    }
    protected virtual void Awake()
    {
        LoadComponent();
    }
    public void LoadComponent()
    {
        if (playerCtrl != null) return;
        playerCtrl = transform.GetComponentInParent<PlayerCtrl>();
    }
}
