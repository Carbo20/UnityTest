using UnityEngine;
using System.Collections;

public class FarmingStats {

    private int xp;
    private int eKill;
    private int dInflicted;
    private int dEndured;
    private int skillUsed;
    private int itemUsed;
    private int level;
    private float time;

    public FarmingStats()
    {
        xp = 0;
        eKill = 0;
        dInflicted = 0;
        dEndured = 0;
        skillUsed = 0;
        itemUsed = 0;
        level = 0;
        time = 0;
    }
    
    public void AddXp(int _xp)
    {
        xp += _xp;
    }
    public void AddEKill()
    {
        eKill++;
    }
    public void AddDInflicted(int _dInflicted)
    {
        dInflicted += _dInflicted;
    }
    public void AddDEndured(int _dEndured)
    {
        dEndured += _dEndured;
    }
    public void AddSkill()
    {
        skillUsed++;
    }
    public void ItemUsed()
    {
        itemUsed++;
    }
    public void Time(float _time)
    {
        time += _time;
    }
}
