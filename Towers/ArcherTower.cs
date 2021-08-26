using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : Tower
{
    public GameObject archers;
    public GameObject arrowPrefab;

    public static string IS_ATTACK = "isAttack";
    public static string IS_CREATE = "isCreate";

    private Animator anim;
    private void Awake()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        anim = archers.GetComponent<Animator>();
        SetPrice(200f);
        SetRange(35f);
        SetBaseTowerRange(35f);
        SetTowerDamage(25f);
        SetBaseTowerDamage(25f);
    }

    public override void Update()
    {
  
        if (getTarget() != null)
        {
            anim.SetBool(IS_ATTACK, true);
            if (getTarget().transform.position.x < archers.transform.position.x)
            {
                archers.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                archers.GetComponent<SpriteRenderer>().flipX = false;
            }

            if (fireCountdown <= 0f)

            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
        else
        {
            anim.SetBool(IS_ATTACK, false);
        }
        base.Update();
    }

    public void Shoot()
    {
        GameObject arrowObject = (GameObject)Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        SoundManager.PlaySound(SoundManager.SoundEffect.ArrowRelease);
        Arrow arrow = arrowObject.GetComponent<Arrow>();
        arrow.setDamage(GetTowerDamage());

        if (arrow != null)
            arrow.Seek(getTarget());
    }
}
