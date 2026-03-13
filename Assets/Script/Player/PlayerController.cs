using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InputManager inputManager;
    public Inventory Inventory;
    public PlayerCtrl PlayerCtrl;
    private void Reset()
    {
        LoadComponent();
    }
    private void Awake()
    {
        LoadComponent();
    }
    public void LoadComponent()
    {
        if (Inventory != null) return;
        Inventory = GetComponentInChildren<Inventory>();
        if (inputManager != null) return;
        inputManager = FindFirstObjectByType<InputManager>();
        if(PlayerCtrl!= null) return;
        PlayerCtrl = FindFirstObjectByType<PlayerCtrl>();
    }
}
