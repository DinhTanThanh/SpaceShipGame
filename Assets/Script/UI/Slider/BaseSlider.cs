using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : LoadMonoBehaviour
{
    [SerializeField] protected Slider slider;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSlider();
    }
    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponent<Slider>();
        Debug.LogWarning("Load slider: " + transform.name);
    }
    protected abstract void OnChangeSlider();
}
