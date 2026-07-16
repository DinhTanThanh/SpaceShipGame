using UnityEngine;

public class UILossGameController : LoadMonoBehaviour
{
    [SerializeField] protected BtnActiveInventory btnActiveInventory;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBtnActiveInventory();
    }
    protected virtual void LoadBtnActiveInventory()
    {
        if (this.btnActiveInventory != null) return;
        this.btnActiveInventory = FindFirstObjectByType<BtnActiveInventory>();
        Debug.LogWarning("Load BtnActiveInventory; " + transform.name);
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.btnActiveInventory.gameObject.SetActive(false);
        SoundFX.Instance.PlayOneShotSoundFailedGame();
    }
}
