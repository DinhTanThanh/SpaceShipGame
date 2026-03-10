using UnityEngine;

public class SpawnMeteorite : MonoBehaviour
{
    public float Timer = 0f;
    public float TimeDelay = 1f;
    public GameObject PosManager;
    public GameObject ManagerMeteorite;
    public GameObject MainCamera;
    private void Reset()
    {
        PosManager = GameObject.Find("PosManager");
        ManagerMeteorite = GameObject.Find("ManagerMeteorite");
        MainCamera = GameObject.Find("Main Camera");
    }
    private void Awake()
    {
        PosManager = GameObject.Find("PosManager");
        ManagerMeteorite = GameObject.Find("ManagerMeteorite");
        MainCamera = GameObject.Find("Main Camera");
    }
    private void Update()
    {
        DelaySpawn();
    }
    public GameObject RandomObject(GameObject objectPrefab)
    {
        int index=Random.Range(0,objectPrefab.transform.childCount);
        return objectPrefab.transform.GetChild(index).gameObject;
    }
    public void Spawn()
    {
        GameObject pos=RandomObject(PosManager);
        GameObject meot= RandomObject(ManagerMeteorite);
        GameObject newObject = Instantiate(meot) ;
        newObject.transform.SetParent(transform);
        Vector3 keepPos = pos.transform.position;
        keepPos.z = 1f;
        newObject.transform.position =keepPos;
        Vector3 temp= newObject.transform.position-MainCamera.transform.position;
        float dir=Mathf.Atan2(pos.transform.position.y,pos.transform.position.x)*Mathf.Rad2Deg;   
        newObject.transform.rotation=Quaternion.Euler(0,0,dir+120);
    }
    public void DelaySpawn()
    {
        Timer += Time.deltaTime;
        if (Timer < TimeDelay) return;
        Timer = 0;
        Spawn();
    }
}
