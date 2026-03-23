using System.Collections.Generic;
using UnityEngine;

public class PoolPrefab : MonoBehaviour
{
    public List<GameObject> ListGameObject= new List<GameObject>();
    public GameObject Spawn(GameObject prefab)
    {
        foreach(GameObject item in ListGameObject)
        {
            if (item.name.Contains(prefab.name))
            {
                ListGameObject.Remove(item);
                return item;
            }
        }
        GameObject objectPrefab = Instantiate(prefab);
        return objectPrefab;
    }
    public virtual GameObject SetPosition(GameObject prefab,Vector3 position,Quaternion rotation)
    {
        GameObject ObPrefab = Spawn(prefab);
        ObPrefab.transform.position = position;
        ObPrefab.transform.rotation = rotation;
        ObPrefab.SetActive(true);
        return ObPrefab;
    }
    public void GoBackList(GameObject prefab)
    {
        ListGameObject.Add(prefab);
    }
}
