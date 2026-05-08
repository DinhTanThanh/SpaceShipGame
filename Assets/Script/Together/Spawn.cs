using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : LoadMonoBehaviour
{
    [SerializeField] protected static Spawn instance;
    public static Spawn Instance => instance;
    protected override void Awake()
    {
        base.Awake();
        Spawn.instance = this;
    }
    public virtual GameObject SpawnObject(GameObject entityPrefab,Vector3 position, Quaternion rotation)
    {
        GameObject objectIntantiate = Instantiate(entityPrefab, position, rotation);
        return objectIntantiate;
    }

}
