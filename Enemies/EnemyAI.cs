using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class EnemyAI : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;

	// Start is called before the first frame update
	void Start()
    {
        enemy = GetComponent<Enemy>();
		enemy.SetSpeed(enemy.startSpeed);
		target = Waypoints.points[0];
		enemy.SetWaypoint(target);
	}
	void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, target.position, enemy.GetSpeed() * Time.deltaTime);
		if (Vector3.Distance(transform.position, target.position) <= 0.4f && !enemy.GetIsDead())
		{
			GetNextWaypoint();
		}
	}

	void GetNextWaypoint()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
			EndPath();
			return;
		}

		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
		enemy.SetWaypoint(target);
	}

	void EndPath()
	{
		GameMenu.Instance().HealthValue--;
		Destroy(gameObject);
	}
}
