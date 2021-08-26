using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDebuff : Debuff
{
    private float slowFactor;
    private bool isDebuff;

    public IceDebuff(Enemy target) : base(target)
    {
        this.target = target;
        slowFactor = 50f;
        setDuration(3f);
        debuffName = "IceDebuff";
    }

    public override void Update()
    {
        if (!isDebuff)
        {
            target.SetSpeed(target.startSpeed - (slowFactor * target.startSpeed / 100));
            isDebuff = true;
        }
        else
        {
            if (duration > 0f)
            {
                duration -= Time.deltaTime;
                isDebuff = false;
            }
            else
            {
                target.SetSpeed(target.startSpeed);
            }
        }
        base.Update();
    }
}
