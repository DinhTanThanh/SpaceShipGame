using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject objectFollow;
    private void Reset()
    {
        objectFollow = GameObject.Find("ManagerPosPlayer");
    }
    private void Awake()
    {
        objectFollow = GameObject.Find("ManagerPosPlayer");
    }
    private void Update()
    {
        transform.position=objectFollow.transform.position;
        transform.rotation=objectFollow.transform.rotation;
    }
}
