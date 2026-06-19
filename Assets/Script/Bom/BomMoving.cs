using Unity.Mathematics;
using UnityEngine;

public class BomMoving : LoadMonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Transform player;

    public float speed = 8f;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayer();
        this.LoadRigidbody2D();
    }
    private void FixedUpdate()
    {
        this.ThrowBom();
    }
    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.Find("Player")?.transform;
    }
    protected virtual void LoadRigidbody2D()
    {
        if (this.rb != null) return;
        this.rb = GetComponentInParent<Rigidbody2D>();
        Debug.LogWarning("Load Rigidbody2D:" + transform.name);    
    }
    protected void ThrowBom()
    {
        Vector2 start = transform.parent.position;
        Vector2 target = player.position;

        float gravity = Mathf.Abs(Physics2D.gravity.y);

        float distance = target.x - start.x;
        float time = Mathf.Abs(distance) / this.speed;
        float vx = distance / time;
        float vy = (target.y - start.y + 0.5f * gravity * time * time) / time;
        this.rb.linearVelocity = new Vector2(vx, vy);
    }
}
