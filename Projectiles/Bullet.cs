using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Bullet : MonoBehaviour
{
	private Transform target;
	public Rigidbody2D rb;

	private float damage;

	public void Seek(Transform target)
	{
		this.target = target;
	}

	public void HitTarget()
	{
		Damage(target);
		Destroy(gameObject);
	}

	public void Damage(Transform enemy)
	{
		Enemy e = enemy.GetComponent<Enemy>();

		if (e != null)
		{
			e.TakeDamage(damage);
			UtilsClass.CreateWorldTextPopup(null, damage.ToString(), e.transform.position, 40, Color.red, e.transform.position + new Vector3(0, 20), 0.5f);
		}
	}

	public Transform getTarget()
    {
		return target;
    }

	public float getDamage()
    {
		return damage;
    }

	public void setDamage(float damage)
    {
		this.damage = damage;
    }
}
