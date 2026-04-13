using UnityEngine;

public abstract class ShottingController : LoadMonoBehaviour
{
    [SerializeField] protected ShottingSO shottingSO;
    public ShottingSO ShottingSO { get { return shottingSO; } }
    public abstract void LoadMeteoriteSO();
}
