using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDebuff : Debuff
{
    public FireDebuff(Enemy target) : base(target)
    {
        this.target = target;
    }

    public override void Update()
    {
        base.Update();
    }
}
