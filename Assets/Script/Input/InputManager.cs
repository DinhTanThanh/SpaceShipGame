using Unity.VisualScripting;
using UnityEngine;

public class InputManager : LoadMonoBehaviour
{
    public float clickMouse;
    [SerializeField] protected static InputManager instance;
    public static InputManager Instance => instance;
    [SerializeField] protected Vector4 direction;
    public Vector4 Direction => direction;
    [SerializeField] protected Vector3 mousePosition;
    public Vector3 MousePosition => mousePosition;
    
    protected override void Awake()
    {
        base.Awake();
        InputManager.instance = this;
    }
    private void Update()
    {
        this.clickMouse = Input.GetAxis("Fire1");
        this.GetDirectionKeyDown();
        this.GetMousePosition();
    }
    protected void GetDirectionKeyDown()
    {
        this.direction.x = Input.GetKeyDown(KeyCode.A) ? 1 : Input.GetKeyDown(KeyCode.LeftArrow) ? 1 : 0;
        if (this.direction.x == 1) Debug.Log("Left");
        this.direction.y = Input.GetKeyDown(KeyCode.D) ? 1 : Input.GetKeyDown(KeyCode.RightArrow) ? 1 : 0;
        if (this.direction.y == 1) Debug.Log("Right");
        this.direction.z = Input.GetKeyDown(KeyCode.W) ? 1 : Input.GetKeyDown(KeyCode.UpArrow) ? 1 : 0;
        if (this.direction.z == 1) Debug.Log("Up");
        this.direction.w = Input.GetKeyDown(KeyCode.S) ? 1 : Input.GetKeyDown(KeyCode.DownArrow) ? 1 : 0;
        if (this.direction.w == 1) Debug.Log("Down");
    }
    protected void GetMousePosition()
    {
        this.mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
