using Unity.VisualScripting;
using UnityEngine;

public class InputManager : LoadMonoBehaviour
{
    [SerializeField] protected bool pressSpace =false;
    [SerializeField] protected static InputManager instance;
    [SerializeField] protected Vector4 direction;
    [SerializeField] protected Vector3 mousePosition;
    public float clickMouse;
    public bool PressSpace => pressSpace;
    public static InputManager Instance => instance;
    public Vector4 Direction => direction;
    public Vector3 MousePosition => mousePosition;
    
    protected override void Awake()
    {
        base.Awake();
        InputManager.instance = this;
    }
    private void Update()
    {
        this.clickMouse = Input.GetAxis("Fire1");
        this.pressSpace = Input.GetKey(KeyCode.Space);
        this.GetDirectionKeyDown();
        this.GetMousePosition();
    }
    protected void GetDirectionKeyDown()
    {
        this.direction.x = Input.GetKeyDown(KeyCode.A) ? 1 : 0;
        if (this.direction.x == 1) Debug.Log("Left");
        this.direction.y = Input.GetKeyDown(KeyCode.D) ? 1 : 0;
        if (this.direction.y == 1) Debug.Log("Right");
        this.direction.z = Input.GetKeyDown(KeyCode.W) ? 1 : 0;
        if (this.direction.z == 1) Debug.Log("Up");
        this.direction.w = Input.GetKeyDown(KeyCode.S) ? 1 : 0;
        if (this.direction.w == 1) Debug.Log("Down");
    }
    protected void GetMousePosition()
    {
        this.mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
