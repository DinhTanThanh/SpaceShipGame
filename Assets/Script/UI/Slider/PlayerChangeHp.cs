using UnityEngine;
using UnityEngine.UI;

public class PlayerChangeHp : LoadMonoBehaviour
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
        this.image=GetComponent<Image>();
        Debug.LogWarning("Load Image: "+transform.name);
    }
    private void FixedUpdate()
    {
        float hp = this.playerController.DameReceiver.Hp;
        float maxHP = this.playerController.DameReceiver.MaxHp;
        float percentHp = Mathf.Clamp01(hp / maxHP);
        this.image.fillAmount = percentHp;
    }
}
