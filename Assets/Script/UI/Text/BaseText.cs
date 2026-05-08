using TMPro;
using UnityEngine;

public class BaseText : LoadMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textMeshProUGUI;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTextMeshProUGUI();
    }
    protected virtual void LoadTextMeshProUGUI()
    {
        if (this.textMeshProUGUI != null) return;
        this.textMeshProUGUI=GetComponent<TextMeshProUGUI>();
        Debug.LogWarning("Load TextMeshProUGUI: " + transform.name);
    }
}
