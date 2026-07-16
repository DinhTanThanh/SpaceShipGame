using UnityEngine;

public class PlayerPushBack : MonoBehaviour
{
    [SerializeField] protected bool isCollision = false;
    [SerializeField] protected float speedPushback = 0.013f;
    [SerializeField] protected Vector3 posBoss;
    public bool IsCollision => isCollision;
    public Vector3 PosBoss => posBoss;
    private void OnTriggerStay2D(Collider2D collision)
    {
        ShootingController bossController = collision.gameObject.GetComponentInParent<ShootingController>();
        if (bossController != null)
        {
            if(bossController is not PlayerController && bossController is not SupportShipController)
            {
                this.posBoss = bossController.transform.position;
                this.isCollision = true;
                return;
            }
        }
        this.isCollision = false;
    }
    public virtual void PushBack()
    {
        Vector3 dir = (this.transform.parent.position - this.posBoss).normalized;
        this.transform.parent.position += (Vector3)dir * this.speedPushback;
    }
}
