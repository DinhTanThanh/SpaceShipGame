using UnityEngine;

public class SpawnBullet : PoolPrefab
{
    public static SpawnBullet instance;
    protected override void LoadComponent()
    {
        SpawnBullet.instance = this;
    }
    public override GameObject Spawn(GameObject prefab)
    {
        foreach (GameObject item in this.ListGameObject)
        {
            if (item != null && item.name.Replace("(Clone)","").CompareTo(prefab.name)==0)
            {
                this.ListGameObject.Remove(item);
                return item;
            }
        }
        GameObject objectPrefab = Instantiate(prefab);
        return objectPrefab;
    }
}
