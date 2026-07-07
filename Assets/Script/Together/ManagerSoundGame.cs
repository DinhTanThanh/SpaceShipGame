using UnityEngine;

public class ManagerSoundGame : LoadMonoBehaviour
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
