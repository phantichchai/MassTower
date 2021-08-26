using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Debuff
{
    protected Enemy target;
    protected float duration;
    protected static string debuffName;

    public Debuff(Enemy target)
    {
        this.target = target;
    }

    public virtual void Update()
    {

    }

    public virtual float getDuration()
    {
        return duration;
    }
    public virtual void setDuration(float duration)
    {
        this.duration = duration;
    }

    public string getDebuffName()
    {
        return debuffName;
    }
}
