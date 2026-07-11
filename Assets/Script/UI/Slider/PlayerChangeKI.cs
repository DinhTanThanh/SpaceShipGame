using UnityEngine;
using UnityEngine.UI;

public class PlayerChangeKI : LoadMonoBehaviour
{
    [SerializeField] protected Image image;
    [SerializeField] protected PlayerController playerController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerController();
        this.LoadImage();
    }
    protected virtual void LoadPlayerController()
    {
        if (this.playerController != null) return;
        this.playerController = FindFirstObjectByType<PlayerController>();
        Debug.LogWarning("Load PlayerController: " + transform.name);
    }
    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = GetComponent<Image>();
        Debug.LogWarning("Load Image: " + transform.name);
    }
    private void FixedUpdate()
    {
        float ki = this.playerController.DameReceiver.KI;
        float maxKI = this.playerController.DameReceiver.MaxKI;
        float percentKI = Mathf.Clamp01(ki / maxKI);
        this.image.fillAmount = percentKI;
    }
}
