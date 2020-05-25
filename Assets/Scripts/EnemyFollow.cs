using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for simple enemy that will follow the player in 2D scene (Enemy_Follow_Player)
public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public float stoppingDist;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position,target.position) >= stoppingDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {            
            Debug.Log("Game Over");
        }
    }
}
