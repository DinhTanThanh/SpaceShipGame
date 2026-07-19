using UnityEngine;

public class SpawnShootingAbleObject : PoolPrefab
{
    [SerializeField] protected float timeDelay = 1f;
    public float TimeDelay => timeDelay;
    [SerializeField] protected float timer = 0f;
    public float Timer => timer;
    [SerializeField] protected GameObject posManager;
    public GameObject PosManager => posManager;
    [SerializeField] protected GameObject monterManager;
    public GameObject MonterManager => monterManager;
    [SerializeField] protected string namePosManager;
    public string NamePosManager => namePosManager;
    [SerializeField] protected string nameMonterManager;
    public string NameMonterManager => nameMonterManager;
   
    protected virtual void SetNameManager()
    {
        this.namePosManager = "Default";
        this.nameMonterManager= "Default";
    }
    public Transform RandomObject(Transform objectPrefab)
    {
        int index = Random.Range(0, objectPrefab.childCount);
        return objectPrefab.GetChild(index);
    }
    public Transform SpawnRandom_Object()
    {
        Transform posSpawn = RandomObject(PosManager.transform);
        Transform shootSpawn = RandomObject(MonterManager.transform);
        Vector3 keepPos = posSpawn.position;
        keepPos.z = 1f;
        GameObject newObject = SetPosition(shootSpawn.gameObject, keepPos, Quaternion.identity);
        newObject.transform.SetParent(transform);
        float dir = Mathf.Atan2(posSpawn.position.y, posSpawn.position.x) * Mathf.Rad2Deg;
        newObject.transform.rotation = Quaternion.Euler(0, 0, dir +120);
        return newObject.transform;
    }
    protected bool DelaySpawn()
    {
        this.timer += Time.deltaTime;
        if (Timer < TimeDelay) return false;
        timer = 0f;
        return true;
    }
    protected bool CheckCountChildMonter(int limitCountChild)
    {
        if (CountChildEnable() >= limitCountChild) return false;
        return true;
    }
    protected int CountChildEnable()
    {
        int count = 0;
        int totalChildren = transform.childCount;

        for (int i = 0; i < totalChildren; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.gameObject.activeSelf)
            {
                count++;
            }
        }
        return count;
    }
    protected virtual void SetTimeDelay()
    {
        this.timeDelay = 1f;
    }
}
