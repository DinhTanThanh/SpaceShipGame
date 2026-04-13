using UnityEngine;

public class DeSpawn : LoadMonoBehaviour
{
    public GameObject SpawnObject(GameObject gameObject,Vector3 pos,Quaternion rot)
    {
        GameObject objectInstance = Instantiate(gameObject);
        objectInstance.transform.position = pos;
        objectInstance.transform.rotation= rot;
        return objectInstance;
    }
}
