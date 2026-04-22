using UnityEngine;

public class ObjectBeenPosition : LoadMonoBehaviour
{
    [SerializeField] protected string nameGameObjectPosition;
    public string NameGameObjectPosition => nameGameObjectPosition;
    [SerializeField] protected GameObject gameObjectPosition;
    public GameObject GameObjectPosition => gameObjectPosition;
    protected void GetNameGameObjectPosition()
    {
        this.nameGameObjectPosition = "Pos" + transform.parent.name;
        this.gameObjectPosition = GameObject.Find(nameGameObjectPosition);
    }
}
