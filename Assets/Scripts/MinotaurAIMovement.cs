using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MinotaurAIMovement : MonoBehaviour
{
    public Transform target; 

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    public Transform minotaur;
    public GameObject enemy;

    bool canFly = true;
    bool onGround = true;

    public float jumpHeight; 

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb; 

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        enemy.GetComponent<BoxCollider2D>();

        InvokeRepeating("UpdatePath", 0f, .5f); 
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return; 
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        } 

        if (canFly)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            Vector2 velocity = rb.velocity;

            //rb.AddForce(force);
            velocity = force;
            rb.velocity = velocity; 
        }
        else
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position);
            Vector2 force = direction * speed * Time.deltaTime;

            //if (path.vectorPath = Vector2(0f, 0.94f))
            //{
                //enemy.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
            //}
            

            //if (direction = new Vector2(0f, 0.94f)) 
            //{
            //enemy.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
            //}

                //if (direction = (0f, 0.094f) 

            Vector2 velocity = rb.velocity;

            velocity.x = force.x;
            rb.velocity = velocity;
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]); 

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (rb.velocity.x >= 0.01f)
        {
            minotaur.localScale = new Vector3(-1f, 1f, 1f); 
        }
        else if (rb.velocity.x <= -0.01f)
        {
            minotaur.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
