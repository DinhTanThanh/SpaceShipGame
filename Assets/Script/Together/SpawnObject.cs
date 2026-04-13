using UnityEngine;

public class SpawnObject : DeSpawn
{
    public float Timer = 0f;
    public float TimeDelay = 1f;
    public GameObject PosManager;
    public GameObject EnemyManager;
    public bool DelaySpawn()
    {
        Timer += Time.deltaTime;
        if (Timer < TimeDelay) return false;
        Timer = 0;
        return true;
    }
}
