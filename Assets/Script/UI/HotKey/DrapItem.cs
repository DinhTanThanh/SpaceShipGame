using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrapItem : LoadMonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] protected Transform realParent;
    [SerializeField] protected Image image;
    public Image Image => image;
    public virtual void SetRealParent(Transform realParent)
    {
        this.realParent = realParent;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadImage();
    }
    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = GetComponent<Image>();
        Debug.LogWarning("Load Image: " + transform.name);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        this.realParent = transform.parent;
        transform.SetParent(HotKeyController.Instance.transform);
        this.image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        Vector3 vectorDrap = InputManager.Instance.MousePosition;
        vectorDrap.z = 0;
        transform.position = vectorDrap;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        transform.SetParent(this.realParent);
        this.image.raycastTarget = true;
    }
}
