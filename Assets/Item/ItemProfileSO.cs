using UnityEngine;
[CreateAssetMenu(fileName ="DefaultName",menuName ="ScriptableObject/ItemProfile")]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode itemCode=ItemCode.NullItem;
    public ItemType itemType=ItemType.ItemNull;
    public string nameItem = "no-name";
    public int defaultStack = 7;
}
