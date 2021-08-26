using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Bullet
{
	public float speed = 5f;

    void Update()
	{
		if (getTarget() == null)
		{
			Destroy(gameObject);
			return;
		}

		Vector3 dir = getTarget().position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;
		if (dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			SoundManager.PlaySound(SoundManager.SoundEffect.ArrowImpact);
			return;
		}

		transform.position = Vector3.MoveTowards(transform.position, getTarget().position, speed * Time.deltaTime);
		Vector2 lookDir = new Vector2(transform.position.x, transform.position.y) - rb.position;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
		rb.rotation = angle;
	}

}
