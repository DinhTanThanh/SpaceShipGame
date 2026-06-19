using UnityEngine;

public class TonadoMoving : MonoBehaviour
{
    [SerializeField] protected float speed=0.01f;
    private void Update()
    {
        this.Moving();
    }
    protected void Moving()
    {
        this.transform.parent.Translate(this.speed * Vector3.right);
    }
}
