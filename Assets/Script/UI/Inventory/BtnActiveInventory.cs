using UnityEngine;

public class BtnActiveInventory : BaseButton
{
    protected override void OnClick()
    {
        BtnInventory.Instance.ActiveInventory();
    }
}
