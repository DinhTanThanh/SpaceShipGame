using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InputManager inputManager;
    private void Reset()
    {
        inputManager=FindFirstObjectByType<InputManager>();
    }
    private void Awake()
    {
        inputManager = FindFirstObjectByType<InputManager>();
    }
}
