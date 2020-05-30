using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolTD : MonoBehaviour
{
    public float speed;
    private WayPoints wayPoints;
    private int wayPointIndex = 0;
    private void Start()
    {
        wayPoints = GameObject.FindGameObjectWithTag("WayPoints").GetComponent<WayPoints>();
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoints.wayPoints[wayPointIndex].position, speed * Time.deltaTime);
        
        Vector3 dir = wayPoints.wayPoints[wayPointIndex].position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if(Vector2.Distance(transform.position, wayPoints.wayPoints[wayPointIndex].position) < 0.1f)
        {            
            if(wayPointIndex <wayPoints.wayPoints.Length - 1)
            {
                wayPointIndex++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
