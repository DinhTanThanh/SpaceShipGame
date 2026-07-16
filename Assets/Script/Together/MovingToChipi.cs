using UnityEngine;

public class MovingToChipi : LoadMonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected ChipiNoticeController chipiNoticeController;
    protected override void Reset()
    {
        base.Reset();
        this.SetSpeed(5f);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadChipiNoticeController();
    }
    protected virtual void LoadChipiNoticeController()
    {
        if (this.chipiNoticeController != null) return;
        this.chipiNoticeController = FindFirstObjectByType<ChipiNoticeController>();
        Debug.LogWarning("Load ChipiNoticeController: " + transform.name);
    }
    protected virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    private void Update()
    {
        this.Moving();
    }
    protected virtual void Moving()
    {
        if (this.chipiNoticeController == null) return;
        Vector3 position = this.transform.parent.position;
        Vector3 posTarget = this.chipiNoticeController.PositionNotice.position;
        Vector3 newPosition = Vector3.Lerp(position, posTarget, this.speed * Time.deltaTime);
        newPosition.z = -10f;
        this.transform.parent.position = newPosition;
    }
}
