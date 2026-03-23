using UnityEngine;

public class ItemEnableByDistance : EnableByDistanceAbstract
{
    protected override void LoadComponet()
    {
        gameObjectBeFollow = GameObject.Find("Player");
        distanceLimit = 70f;
    }
    private void Update()
    {
        if (!IsDistanceAchiveLimit()) return;
        SpawnItems.instance.GoBackList(transform.parent.gameObject);
        transform.parent.gameObject.SetActive(false);
    }
}
