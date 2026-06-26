using UnityEngine;

public class ShakeCamera : LoadMonoBehaviour
{
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected bool isShake = false;
    [SerializeField] protected Transform mainCamera;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMainCamera();
    }
    private void FixedUpdate()
    {
        if (!this.isShake) return;
        this.Shake(2f,0.4f);
    }
    protected virtual void LoadMainCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = transform.Find("Main Camera");
        Debug.LogWarning("Load Main Camera: " + transform.name);
    }
    public virtual void SetIsShake(bool isShake)
    {
        this.isShake = isShake;
    }
    protected virtual void Shake(float time,float magnitude)
    {
        if (this.Timing(time))
        {
            this.isShake = false;
            return;
        }
        float x = Random.Range(-1f, 1f) * magnitude;
        float y = Random.Range(-1f, 1f) * magnitude;
        this.mainCamera.localPosition= new Vector3(x,y,0);
    }
    protected virtual bool Timing(float timeDelay)
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer < timeDelay) return false;
        this.timer = 0f;
        return true;
    }
}
