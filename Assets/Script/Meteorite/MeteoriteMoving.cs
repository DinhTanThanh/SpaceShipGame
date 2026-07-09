using UnityEngine;

public class MeteoriteMoving : MonoBehaviour
{
    public float speed = 0.04f;
    private void Update()
    {
        transform.parent.Translate(Vector3.up*speed);
    }
}
