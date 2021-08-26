using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBullet : Bullet
{
    private void Start()
    {
		setDamage(100f);
    }
    private void Update()
	{
		if (getTarget() == null)
		{
			Destroy(gameObject);
			return;
		}

		transform.position = new Vector3(getTarget().position.x, getTarget().position.y + 15f, 0);
	}

	public void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.GetComponent<Transform>().Equals(getTarget()))
        {
			HitTarget();
			SoundManager.PlaySound(SoundManager.SoundEffect.StoneImpact);
		}
	}

	new public void HitTarget()
    {
		Damage(getTarget());
		Destroy(gameObject);
	}
}
