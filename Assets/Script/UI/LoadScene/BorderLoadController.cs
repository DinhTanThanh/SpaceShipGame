using TMPro;
using UnityEngine;

public class BorderLoadController : LoadMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI percentLoadScene;
    public TextMeshProUGUI PercentLoadScene => percentLoadScene;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPercentLoadScene();
    }
    protected virtual void LoadPercentLoadScene()
    {
        if (this.percentLoadScene != null) return;
        this.percentLoadScene = GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning("Load PercentLoadScen: " + transform.name);
    }
}
