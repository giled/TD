using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
    
{

    private Transform target;

    private int wavepointIndex = 0;

    private Enemy enemy;
    void Start()
    {
        target = kelias.points[0];
        enemy = GetComponent<Enemy>();
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();

        }
        enemy.speed = enemy.startSpeed;

    }
    void GetNextWaypoint()
    {
        if (wavepointIndex >= kelias.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = kelias.points[wavepointIndex];

    }
    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }


}
