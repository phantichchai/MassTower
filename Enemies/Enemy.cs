using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 1f;
	public float startHitpoint = 100f;


	[Header("Unity Stuff")]
	public Image hitpointBar;

	private Animator anim;
	private SpriteRenderer sprite;
	private Transform waypoint;
	public List<Debuff> debuffs = new List<Debuff>();
	private float hitpoint;
	private float speed;
	private bool isDead = false;
	[SerializeField] private float earnMoney;


	private static string IS_DEAD = "isDead";

    void Update()
    {
		HandlerDebuffs();
		Render();
	}
	void Start()
	{
		speed = startSpeed;
		hitpoint = startHitpoint;
		anim = GetComponentInChildren<Animator>();
		sprite = GetComponentInChildren<SpriteRenderer>();
		earnMoney = 10f;
	}

	public float GetSpeed()
    {
		return speed;
    }

	public void SetSpeed(float speed)
    {
		this.speed = speed;
    }

	public void SetEarnMoney(float earnMoney)
    {
		this.earnMoney = earnMoney;
    }

	public float GetHitpoint()
    {
		return hitpoint;
    }

	public bool GetIsDead()
    {
		return isDead;
    }


	public void TakeDamage(float amount)
	{
		hitpoint -= amount;

		hitpointBar.fillAmount = hitpoint / startHitpoint;

		if (hitpoint <= 0 && !isDead)
		{
			Die();
		}
	}

	public void Die()
	{
		GameMenu.Instance().MoneyValue += earnMoney;
		isDead = true;
		anim.SetBool(IS_DEAD, isDead);
		Destroy(gameObject, 1f);
	}

	public void SetWaypoint(Transform waypoint)
    {
		this.waypoint = waypoint;
    }

	public void AddDebuff(Debuff debuff)
    {
		if (!debuffs.Exists(x => x.GetType() == debuff.GetType()))
		{
			debuffs.Add(debuff);
		}
        else
        {
			foreach (Debuff d in debuffs)
            {
				if (d.getDebuffName() == debuff.getDebuffName())
                {
					d.setDuration(d.getDuration());
                }
            }
        }
	}

	public void HandlerDebuffs()
    {
		foreach (Debuff debuff in debuffs)
        {
			debuff.Update();
        }
    }

    public void Render()
    {
		if (sprite.transform.position.x > waypoint.position.x)
        {
			sprite.flipX = true;
        }
        else
        {
			sprite.flipX = false;
        }
    }
}
