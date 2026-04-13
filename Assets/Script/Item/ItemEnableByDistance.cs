using UnityEngine;

public class ItemEnableByDistance : EnableByDistanceAbstract
{
    protected override void LoadComponent()
    {
        this.gameObjectBeFollow = GameObject.Find("Player");
        this.distanceLimit = 70f;
    }
    private void Update()
    {
        if (!IsDistanceAchiveLimit()) return;
        SpawnItems.instance.GoBackList(transform.parent.gameObject);
        transform.parent.gameObject.SetActive(false);
    }
}
