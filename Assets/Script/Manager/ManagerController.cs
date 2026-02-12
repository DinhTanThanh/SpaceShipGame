using UnityEngine;

public class ManagerController : LoadComponentGame
{
    [SerializeField] protected static ManagerController instance;
    public static ManagerController Instance=>instance;
    [SerializeField] protected InputController inputController;
    public InputController InputController => inputController;
    private void Reset()
    {
        LoadComponent();
    }
    private void Awake()
    {
        ManagerController.instance = this;
        LoadComponent();
    }
    public override void LoadComponent()
    {
        if(inputController== null)
        {
            this.inputController = FindFirstObjectByType<InputController>();
        }
    }
}
