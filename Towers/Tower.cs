using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public abstract class Tower : MonoBehaviour
{
	private float range = 0f;
	private float baseRange = 0f;
	protected float fireRate = 1f;
    private float baseFireRate = 1f;
    private float damage = 10f;
	private float baseDamage = 10f;
	[SerializeField] protected Transform firePoint;
	[SerializeField] protected Transform upgradeOverlay;

	private Transform target;
    private Enemy targetEnemy;
	private float price = 0f;
	protected float fireCountdown = 0f;
	protected bool isOver = false;

	public string ENEMY_TAG = "Enemy";

    public virtual void Update()
    {
		upgradeOverlay.GetComponentInChildren<SpriteRenderer>().transform.localScale = 2f * Vector2.one * (range / 10f);

		if (Input.GetMouseButtonDown(1))
		{
			upgradeOverlay.gameObject.SetActive(false);
		}

		if (!isOver && !upgradeOverlay.GetComponentInChildren<Upgrade>().GetOnUpgrade())
        {
			if (Input.GetMouseButtonDown(0))
			{
				upgradeOverlay.gameObject.SetActive(false);
			}
		}
	}

	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(ENEMY_TAG);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range)
		{
			target = nearestEnemy.transform;
			targetEnemy = nearestEnemy.GetComponent<Enemy>();
		}
		else
		{
			target = null;
		}

	}

	public float GetRange()
    {
		return range;
    }

	public void SetRange(float range)
    {
		this.range = range;
    }
	public float GetPrice()
    {
		return price;
    }

	public void SetPrice(float price)
    {
		this.price = price;
    }

	public Transform getTarget()
    {
		return target;
    }

	public Enemy getTargetEnemy()
    {
		return targetEnemy;
    }
	
	public float GetTowerDamage()
    {
		return damage;
    }

	public void SetTowerDamage(float damage)
    {
		this.damage = damage;
    }

	public float GetBaseTowerDamage()
    {
		return baseDamage;
    }

	public void SetBaseTowerDamage(float baseDamage)
	{
		this.baseDamage = baseDamage;
	}

	public float GetBaseTowerRange()
	{
		return baseRange;
	}

	public void SetBaseTowerRange(float baseRange)
	{
		this.baseRange = baseRange;
	}

	public float GetBaseFireRate()
	{
		return baseFireRate;
	}

	public void SetBaseFireRate(float baseFireRate)
	{
		this.baseFireRate = baseFireRate;
	}

	public float GetFireRate()
    {
		return fireRate;
    }

	public void SetFireRate(float fireRate)
    {
		this.fireRate = fireRate;
    }

	private void OnMouseOver()
    {
		isOver = true;
		if (Input.GetMouseButtonDown(0))
		{
			upgradeOverlay.gameObject.SetActive(true);
		}
	}

    private void OnMouseExit()
    {
		isOver = false;
    }
}
