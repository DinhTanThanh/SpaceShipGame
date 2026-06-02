using UnityEngine;

public class MeteoriteMoving : MonoBehaviour
{
    public float speed = 0.01f;
    private void Update()
    {
        transform.parent.Translate(Vector3.up*speed);
    }
}
