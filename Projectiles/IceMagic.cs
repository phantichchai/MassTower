using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMagic : Bullet
{
    private IceDebuff iceDebuff;
    void Update()
    {
        if (getTarget() == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = getTarget().position;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Transform>().Equals(getTarget()))
        {
            HitTarget();
            ApplyDebuff();
        }
    }

    new public void HitTarget()
    {
        Damage(getTarget());
        Destroy(gameObject, 1f);
        SoundManager.PlaySound(SoundManager.SoundEffect.IceImpact);
    }


    private void ApplyDebuff()
    {
        Enemy target = getTarget().GetComponent<Enemy>();
        if (target != null)
        {
            iceDebuff = new IceDebuff(target);
            target.AddDebuff(iceDebuff);
        }
    }
}
