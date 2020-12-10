using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollision : MonoBehaviour
{
    public GameObject deathCollisionBox;
    public GameObject jumpDeathCollisionBox;

    public GameObject counter;

    public bool isJumping = false;

    void Start()
    {
        deathCollisionBox.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void Update()
    {
        //if (isJumping == true)
        //{
            //deathCollisionBox.GetComponent<BoxCollider2D>().enabled = false;
        //}

        //else if (isJumping == false)
        //{
            deathCollisionBox.GetComponent<BoxCollider2D>().enabled = true; 
        //}

        //if (Input.GetKeyDown(KeyCode.Space) == true)
        //{
            //if (isJumping != true)
            //{
                //isJumping = true;
            //}
        //}
    }

    //public void OnCollisionEnter2D(Collision2D collision)
    //{
        //if (collision.gameObject.name == "Ground")
        //{
            //isJumping = false;
        //}
    //}

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag == "GameOver")
        {
            counter.GetComponent<Counter>().Lose();
        }
    }
}
