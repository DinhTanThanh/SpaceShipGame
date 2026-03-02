using UnityEngine;

public class Around : MonoBehaviour
{
    public Quaternion rot=Quaternion.Euler(0,0,1);
    private void Update()
    {
        transform.rotation *= rot;
    }
}
