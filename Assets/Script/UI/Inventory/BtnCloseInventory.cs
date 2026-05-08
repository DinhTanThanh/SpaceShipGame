using UnityEngine;

public class BtnCloseInventory : BaseButton
{
    [SerializeField] protected bool isOpen=false;
    protected override void OnClick()
    {
        BtnInventory.Instance.CloseInventory();
    }

}
