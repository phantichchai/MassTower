using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : Tower
{
    public GameObject iceMagicPrefab;

    void Awake()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        SetFireRate(0.5f);
        SetBaseFireRate(0.5f);
        SetPrice(300f);
        SetRange(60f);
        SetBaseTowerRange(60f);
        SetTowerDamage(10f);
        SetBaseTowerDamage(10f);
    }

    public override void Update()
    {
        if (getTarget() != null)
        {
            if (fireCountdown <= 0f)

            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
        base.Update();
    }

    public void Shoot()
    {
        GameObject iceMagicObject = (GameObject)Instantiate(iceMagicPrefab, firePoint.position, firePoint.rotation);
        IceMagic ice = iceMagicObject.GetComponent<IceMagic>();
        ice.setDamage(GetTowerDamage());

        if (ice != null)
            ice.Seek(getTarget());
    }
}
