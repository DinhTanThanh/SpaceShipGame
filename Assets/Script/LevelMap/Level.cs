using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int levelCurrent = 1;
    [SerializeField] private int levelMax = 99;
    public int LevelCurrent => levelCurrent;
    public int LevelMax => levelMax;
    protected void LevelUp()
    {
        levelCurrent++;
        LevelLimit();
    }
    protected void LevelUp(int level)
    {
        levelCurrent = level;
        LevelLimit();
    }
    protected void LevelLimit()
    {
        if (levelCurrent > levelMax) levelCurrent = levelMax;
        else if (levelCurrent < 1) levelCurrent = 1;
    }
}
