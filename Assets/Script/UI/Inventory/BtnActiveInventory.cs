using UnityEngine;

public class BtnActiveInventory : BaseButton
{
    protected override void OnClick()
    {
        SoundFX.Instance.PlayOneShotSoundClick();
        BtnInventory.Instance.ActiveInventory();
    }
}
