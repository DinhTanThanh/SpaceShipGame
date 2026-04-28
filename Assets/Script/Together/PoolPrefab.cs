using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PoolPrefab : LoadMonoBehaviour
{
    [SerializeField] protected int sttObject = 1;
    [SerializeField] protected int sttLimitObject = 0;
    public List<GameObject> ListGameObject= new List<GameObject>();
    protected virtual void SetLimitObject()
    {
        this.sttLimitObject = 0;
    }
    public GameObject Spawn(GameObject prefab)
    {
        foreach(GameObject item in ListGameObject)
        {
            if (item!=null)
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
        if (sttObject <= sttLimitObject)
        {
            ObPrefab.name = transform.name.Replace("MinionSummon", "") + "_" + sttObject;
            this.sttObject++;
        }
        ObPrefab.SetActive(true);
        return ObPrefab;
    }
    public void GoBackList(GameObject prefab)
    {
        ListGameObject.Add(prefab);
    }
}
