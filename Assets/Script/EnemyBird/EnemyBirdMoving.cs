using UnityEngine;

public class EnemyBirdMoving : MonoBehaviour
{
    [SerializeField] protected float speed = 0.1f;
    private void Update()
    {
        this.transform.parent.Translate(this.speed * Vector3.down);
        Vector3 pos=this.transform.parent.position;
        pos.z = 0f;
        this.transform.parent.position = pos;
    }
}
