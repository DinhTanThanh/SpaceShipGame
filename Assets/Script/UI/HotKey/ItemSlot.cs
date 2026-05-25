using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : LoadMonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount > 0) return;
        Debug.Log("On Drop Item Slot");
        GameObject item = eventData.pointerDrag;
        DrapItem itemDrap=item.GetComponent<DrapItem>();
        itemDrap.SetRealParent(transform);
    }
}
