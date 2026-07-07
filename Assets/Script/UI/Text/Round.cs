using TMPro;
using UnityEngine;

public class Round : LoadMonoBehaviour
{
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeDelay = 0.5f;
    [SerializeField] protected TextMeshProUGUI textMeshProUGUI;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTextMeshProUGUI();
    }
    protected virtual void LoadTextMeshProUGUI()
    {
        if (this.textMeshProUGUI != null) return;
        this.textMeshProUGUI=GameObject.Find("UIRoundLevel")?.GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning("Load TextMeshProUGUI: " + transform.name);
    }
    protected virtual void SetStringLevel(string nameLevel)
    {
        this.textMeshProUGUI.text = nameLevel;
    }
    protected virtual bool Timing()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.timeDelay) return false;
        this.timer = 0f;
        return true;
    }
    protected virtual void ActiveTextLevel()
    {
        this.textMeshProUGUI.transform.parent.gameObject.SetActive(true);
    }
    protected virtual void EnableTextLevel()
    {
        if (!this.Timing()) return;
        Vector3 scale = new Vector3(0.05f, 0.05f, 0.05f);
        while (this.textMeshProUGUI.transform.localScale != Vector3.zero)
        {
            this.textMeshProUGUI.transform.localScale-=scale;
        }
        this.textMeshProUGUI.transform.parent.gameObject.SetActive(false);
    }
    protected virtual void ResetLocalScale()
    {
        this.textMeshProUGUI.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
