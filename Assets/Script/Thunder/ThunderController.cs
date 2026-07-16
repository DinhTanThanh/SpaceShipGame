using UnityEngine;

public class ThunderController : LoadMonoBehaviour
{
    [SerializeField] protected BossSpaceController bossSpaceController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossSpaceController();
    }
    protected virtual void LoadBossSpaceController()
    {
        if (this.bossSpaceController != null) return;
        this.bossSpaceController = FindFirstObjectByType<BossSpaceController>();
        Debug.LogWarning("Load BossSpaceController: " + transform.name);
    }
    private void Update()
    {
        if (!this.bossSpaceController.gameObject.activeSelf) return;
        this.transform.gameObject.SetActive(false);
    }
}
