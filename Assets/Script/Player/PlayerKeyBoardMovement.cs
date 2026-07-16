using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerKeyBoardMovement : LoadMonoBehaviour
{
    [SerializeField] protected float speedMoving = 2f;
    [SerializeField] protected float speedRotation = 0f;
    [SerializeField] protected Vector3 inputMoving;
    [SerializeField] protected Vector3 inputDirect;
    protected override void Awake()
    {
        base.Awake();
        this.speedRotation = 5f;
    }
    private void Update()
    {
        this.MovingByKeyBoard();
    }
    private void FixedUpdate()
    {
        if (this.inputDirect == Vector3.zero) return;
        float angle = Mathf.Atan2(this.inputDirect.y, this.inputDirect.x) * Mathf.Rad2Deg;
        angle -= 90;
        this.transform.parent.rotation= Quaternion.Lerp(this.transform.parent.rotation, Quaternion.Euler(0f, 0f, angle),Time.deltaTime*this.speedRotation);
        this.transform.parent.position += this.inputMoving * this.speedMoving;
    }
    protected void MovingByKeyBoard()
    {
        this.ResetInputVector();
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.inputMoving.y = 0.1f;
            this.inputDirect.y = 1f;
            //float newRotation = this.transform.parent.eulerAngles.z - 10f;
            //if (newRotation >= 0)
            //{
            //    this.inputDirect.z = -10f;
            //}
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.inputMoving.y = -0.1f;
            this.inputDirect.y = -1f;
            //float newRotation = this.transform.parent.eulerAngles.z + 10f;
            //if (newRotation <= 180)
            //{
            //    this.inputDirect.z = 10f;
            //}
            //newRotation = this.transform.parent.eulerAngles.z - 10f;
            //if (newRotation > 180)
            //{
            //    this.inputDirect.z = -10f;
            //}
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.inputMoving.x = 0.1f;
            this.inputDirect.x = 1f;
            //float newRotation = this.transform.parent.eulerAngles.z - 10f;
            //if (newRotation >270)
            //{
            //    Debug.Log(newRotation);
            //    this.inputDirect.z = -10f;
            //}
            //newRotation = this.transform.parent.eulerAngles.z + 10f;
            //if (newRotation <= 270)
            //{
            //    this.inputDirect.z = 10f;
            //}
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.inputMoving.x = -0.1f;
            this.inputDirect.x = -1f;
            //float newRotation = this.transform.parent.eulerAngles.z - 10f;
            //if (newRotation >90)
            //{
            //    this.inputDirect.z = -10f;
            //}
            //newRotation = this.transform.parent.eulerAngles.z + 10f;
            //if (newRotation <= 95)
            //{
            //    this.inputDirect.z = 10f;
            //}
        }
    }
    protected virtual void ResetInputVector()
    {
        this.inputMoving = Vector3.zero;
        this.inputDirect = Vector3.zero;
    }
}
