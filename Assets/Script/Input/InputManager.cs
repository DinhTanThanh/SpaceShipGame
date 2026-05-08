using Unity.VisualScripting;
using UnityEngine;

public class InputManager : LoadMonoBehaviour
{
    [SerializeField] protected static InputManager instance;
    public static InputManager Instance => instance;
    public float clickMouse;
    [SerializeField] protected Vector4 direction;
    public Vector4 Direction => direction;
    public Vector4 Test;
    protected override void Awake()
    {
        base.Awake();
        InputManager.instance = this;
    }
    private void Update()
    {
        this.clickMouse = Input.GetAxis("Fire1");
        GetDirectionKeyDown();
    }
    protected void GetDirectionKeyDown()
    {
        this.direction.x = Input.GetKeyDown(KeyCode.A) ? 1 : Input.GetKeyDown(KeyCode.LeftArrow) ? 1 : 0;
        if (this.direction.x == 1) Debug.Log("Left");
        //if (this.direction.x == 0) this.direction.x = Input.GetKeyDown(KeyCode.LeftArrow) ? 1 : 0;

        this.direction.y = Input.GetKeyDown(KeyCode.D) ? 1 : Input.GetKeyDown(KeyCode.RightArrow) ? 1 : 0;
        if (this.direction.y == 1) Debug.Log("Right");
        // if (this.direction.y == 0) this.direction.y = Input.GetKeyDown(KeyCode.RightArrow) ? 1 : 0;

        this.direction.z = Input.GetKeyDown(KeyCode.W) ? 1 : Input.GetKeyDown(KeyCode.UpArrow) ? 1 : 0;
        if (this.direction.z == 1) Debug.Log("Up");
        //if (this.direction.z == 0) this.direction.z = Input.GetKeyDown(KeyCode.UpArrow) ? 1 : 0;

        this.direction.w = Input.GetKeyDown(KeyCode.S) ? 1 : Input.GetKeyDown(KeyCode.DownArrow) ? 1 : 0;
        if (this.direction.w == 1) Debug.Log("Down");
        //if (this.direction.w == 0) this.direction.w = Input.GetKeyDown(KeyCode.DownArrow) ? 1 : 0;
    }
    protected void TestingDirection()
    {
        if (this.direction.x == 1) this.Test.x = 1;
        if (this.direction.y == 1) this.Test.y = 1;
        if (this.direction.z == 1) this.Test.z = 1;
        if (this.direction.w == 1) this.Test.w = 1;
    }
    protected void SetTest()
    {
        this.Test=Vector4.zero;
    }
}
