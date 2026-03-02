using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float clickMouse;
    private void Update()
    {
        clickMouse = Input.GetAxis("Fire1");
    }
}
