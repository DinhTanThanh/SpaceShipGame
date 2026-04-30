using UnityEngine;

public class Around : MonoBehaviour
{
    public Quaternion rot=Quaternion.Euler(0,0,0.3f);
    private void Update()
    {
        transform.rotation *= rot;
    }
}
