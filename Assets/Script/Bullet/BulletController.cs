using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private GameObject impact;
    public GameObject Impact => impact;
    [SerializeField] private GameObject spawnImpact;
    public GameObject SpawnImpact=> spawnImpact;    
    private void Reset()
    {
        impact = GameObject.Find("Impact");
        spawnImpact = GameObject.Find("SpawnImpact");
    }
    private void Awake()
    {
        impact = GameObject.Find("Impact");
        spawnImpact = GameObject.Find("SpawnImpact");
    }

}
