using JetBrains.Annotations;
using UnityEngine;

public class TxtShipHp : BaseText
{
    [SerializeField] protected PlayerController playerController;
    public PlayerController PlayerController => playerController;
    protected int hp, maxHp;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerController();
    }
    protected virtual void LoadPlayerController()
    {
        this.playerController = FindFirstObjectByType<PlayerController>();
    }
    private void FixedUpdate()
    {
        this.hp = this.playerController.DameReceiver.Hp;
        this.maxHp = this.playerController.DameReceiver.MaxHp;
        string strShowHp = this.hp + " / " + this.maxHp;
        this.textMeshProUGUI.SetText(strShowHp);
    }
}
