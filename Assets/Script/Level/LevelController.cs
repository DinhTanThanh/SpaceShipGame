using System.Collections.Generic;
using UnityEngine;

public class LevelController : LoadMonoBehaviour
{
    [SerializeField] protected int levelCurrent = 1;
    [SerializeField] protected List<Transform> ListLevel=new List<Transform>();
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.GetListLevel();
        this.ActiveLevelCurrent();
    }
    protected virtual void GetListLevel()
    {
        if (this.ListLevel.Count > 0) return;
        foreach(Transform level in this.transform)
        {
            this.ListLevel.Add(level);
        }
    }
    public virtual Transform GetLevelCurrent()
    {
        foreach(Transform level in this.ListLevel)
        {
            if (level.name.Contains(levelCurrent.ToString()))
            {
                return level;
            }
        }
        return null;
    }
    public virtual void ActiveLevelCurrent()
    {
        this.EnableAllLevel();
        Transform level = this.GetLevelCurrent();
        if (level == null)
        {
            Debug.Log("Level null");
            return;
        }
        level.gameObject.SetActive(true);
    }
    public virtual void EnableAllLevel()
    {
        foreach(Transform level in this.ListLevel)
        {
            if (level.gameObject.activeSelf)
            {
                level.gameObject.SetActive(false);
            }
        }
    }
    public virtual void SetLevelCurrent(int numberLevel)
    {
        this.levelCurrent = numberLevel;
    }
    public virtual int GetNumberLevelCurrent()
    {
        return this.levelCurrent;
    }
    public virtual bool CheckLimitLevel()
    {
        return this.levelCurrent>=this.ListLevel.Count;
    }
}
