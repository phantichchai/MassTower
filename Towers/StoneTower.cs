using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneTower : Tower
{

    public GameObject StoneBulletPrefab;

    void Awake()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        SetFireRate(0.2f);
        SetBaseFireRate(0.2f);
        SetPrice(300f);
        SetRange(60f);
        SetBaseTowerRange(60f);
        SetTowerDamage(100f);
        SetBaseTowerDamage(100f);
    }

    // Update is called once per frame
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

    private void Shoot()
    {
        GameObject stoneBullObject = (GameObject)Instantiate(StoneBulletPrefab, firePoint.position, firePoint.rotation);
        StoneBullet stoneBullet = stoneBullObject.GetComponent<StoneBullet>();
        stoneBullet.setDamage(GetTowerDamage());

        if (stoneBullet != null)
            stoneBullet.Seek(getTarget());
    }
}
