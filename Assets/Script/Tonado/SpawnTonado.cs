using System.Collections.Generic;
using UnityEngine;

public class SpawnTonado : PoolPrefab
{
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeDelay = 6f;
    [SerializeField] protected int indexCurrent = 0;
    [SerializeField] protected Transform managetPosTonado;
    [SerializeField] protected GameObject tonado;
    [SerializeField] protected List<Transform> listPositon;
    private static SpawnTonado instance;
    public static SpawnTonado Instance => instance;
    public Transform ManagetPosTonado => managetPosTonado;
    public GameObject Tonado => tonado;
    public List<Transform> ListPosition => listPositon;
    protected override void Awake()
    {
        base.Awake();
        SpawnTonado.instance = this;
    }
    private void Update()
    {
        this.SpawnTonadoObject();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTonado();
        this.LoadManagetPosTonado();
        this.GetListPosition();
    }
    protected virtual void LoadTonado()
    {
        if (this.tonado != null) return;
        this.tonado = GameObject.Find("Tonado");
        Debug.LogWarning("Load Tonado: " + transform.name);
    }
    protected virtual void LoadManagetPosTonado()
    {
        if (this.managetPosTonado != null) return;
        this.managetPosTonado = GameObject.Find("ManagetPosTonado")?.transform;
        Debug.LogWarning("Load ManagetPosTonado: " + transform.name);
    }
    protected virtual void GetListPosition()
    {
        if (this.managetPosTonado == null) return;
        if (this.listPositon.Count > 0) return;
        foreach (Transform pos in this.managetPosTonado)
        {
            this.listPositon.Add(pos);
        }
    }
    protected virtual int GetRandomIndex()
    {
        int index;
        do
        {
            index = Random.Range(0, this.listPositon.Count);
        } while (this.indexCurrent == index);
        return index;
    }
    protected virtual Transform GetPosition()
    {
        this.indexCurrent=this.GetRandomIndex();
        return this.listPositon[this.indexCurrent];
    }
    protected virtual void SpawnTonadoObject()
    {
        if (!this.Timing()) return;
        Transform pos = this.GetPosition();
        GameObject objectTonado= this.SetPosition(this.tonado, pos.position, pos.rotation);
        float randomScale = Random.Range(1f, 2f);
        Vector3 scale = new Vector3(randomScale, randomScale, 1);
        objectTonado.transform.localScale = scale;
        objectTonado.transform.SetParent(transform);
    }
    protected virtual bool Timing()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.timeDelay) return false;
        this.timer = 0f;
        return true;
    }
}
