using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] protected static PlayerCtrl instance;
    public static PlayerCtrl Instance => instance;
    [SerializeField] protected PlayerController shipController;
    public PlayerController ShipController => shipController;
    [SerializeField] protected PlayerPickup playerPickup;
    public PlayerPickup PlayerPickup=> playerPickup;    
    private void Reset()
    {
        LoadComponent();
    }
    private void Awake()
    {
        PlayerCtrl.instance = this;
        LoadComponent();
    }
    public void LoadComponent()
    {
        if (shipController != null) return;
        shipController = FindFirstObjectByType<PlayerController>();
        if (playerPickup != null) return;
        playerPickup=GetComponentInChildren<PlayerPickup>();
    }
}
