using UnityEngine;

public class ImpactEnableByTime : MonoBehaviour
{
    public float Timer = 0f;
    public float timeDelay = 1f;
    private void Update()
    {
        EnableByTime();
    }
    public void EnableByTime()
    {
        Timer += Time.deltaTime;
        if (Timer < timeDelay) return;
        Timer= 0f;
        SpawnImpact.instance.GoBackList(transform.parent.gameObject);
        transform.parent.gameObject.SetActive(false);
    }
}
