using UnityEngine;

public class MovingBullet : LoadMonoBehaviour
{
    public float speed;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.speed = 15f;
    }
    void Update()
    {
        transform.parent.Translate(Vector3.up * speed * Time.deltaTime);
    }
    public virtual void SetSpeedBullet(float speedBullet)
    {
        this.speed = speedBullet;
    }
}
