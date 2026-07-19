using TMPro;
using UnityEngine;

public class ChipiMoving : LoadMonoBehaviour
{
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeDelay = 1.5f;
    [SerializeField] protected bool isStart = true;
    [SerializeField] protected float speed;
    [SerializeField] protected GameObject UINoticeCurrent;
    [SerializeField] protected ChipiNoticeController chipiNoticeController;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.isStart = true;
        this.ActiveUiNotice();
    }
    protected override void Reset()
    {
        base.Reset();
        this.SetSpeed(5f);
    }
    private void Update()
    {
        if (this.isStart)
        {
            this.MoveToPosDestination();
            if (!this.CheckAchiveDistance(this.chipiNoticeController.ListPosNotice[1]))
            {
                return;
            }
            if (!this.Timing()) return;
            this.DisableStart();
        }
        if (!this.isStart)
        {
            this.MoveToPosBegin();
        }
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadChipiNoticeController();
    }
    protected virtual void LoadChipiNoticeController()
    {
        if (this.chipiNoticeController != null) return;
        this.chipiNoticeController = GetComponentInParent<ChipiNoticeController>();
        Debug.LogWarning("Load ChipiNoticeController: " + transform.name);
    }
    protected virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    protected virtual void Moving(Transform target)
    {
        Vector3 position = this.transform.parent.position;
        Vector3 posTarget = target.position;
        Vector3 newPos = Vector3.Lerp(position, posTarget, this.speed * Time.deltaTime);
        newPos.z = -10f;
        this.transform.parent.position = newPos;
    }
    protected virtual bool CheckAchiveDistance(Transform target)
    {
        if (Vector3.Distance(this.transform.parent.position, target.position) < 11f)
        {
            return true;
        }
        return false;
    }
    protected virtual void MoveToPosDestination()
    {
        this.Moving(this.chipiNoticeController.ListPosNotice[1]);
    }
    protected virtual void MoveToPosBegin()
    {
        this.Moving(this.chipiNoticeController.ListPosNotice[0]);
        if (!this.CheckAchiveDistance(this.chipiNoticeController.ListPosNotice[0])) return;
        this.DisableUiNotice();
        this.transform.parent.gameObject.SetActive(false);
    }
    protected virtual void DisableStart()
    {
        this.isStart = false;
    }
    protected virtual void ActiveUiNotice()
    {
        if (this.UINoticeCurrent == null) return;
        this.UINoticeCurrent.SetActive(true);
    }
    protected virtual void DisableUiNotice()
    {
        if (this.UINoticeCurrent == null) return;
        this.UINoticeCurrent.SetActive(false);
    }
    public virtual void SetUINoticeCurrent(GameObject uiNoticeCurrent)
    {
        this.UINoticeCurrent = uiNoticeCurrent;
    }
    protected virtual bool Timing()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.timeDelay) return false;
        this.timer = 0f;
        return true;
    }
}
