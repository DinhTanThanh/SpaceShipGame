using UnityEngine;

public class MovingBullet : MonoBehaviour
{
    public float speed = 15f;
    void Update()
    {
        transform.parent.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
