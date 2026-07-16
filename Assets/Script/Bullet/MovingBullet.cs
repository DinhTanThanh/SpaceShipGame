using UnityEngine;

public class MovingBullet : LoadMonoBehaviour
{
    [SerializeField] protected float speed;
    public float Speed=>speed;
    protected override void Reset()
    {
        base.Reset();
        SetSpeedBullet(25);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
    }
    void Update()
    {
        transform.parent.Translate(Vector3.up* this.speed * Time.deltaTime);
    }
    public virtual void SetSpeedBullet(float speedBullet)
    {
        this.speed = speedBullet;
    }
}
