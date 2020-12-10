using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDeathCollision : MonoBehaviour
{
    public GameObject deathCollisionBox;
    public GameObject jumpDeathCollisionBox;
    public GameObject counter;

    public bool isJumping = false; 

    // Start is called before the first frame update
    void Start()
    {
        jumpDeathCollisionBox.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            jumpDeathCollisionBox.GetComponent<BoxCollider2D>().enabled = true;

            isJumping = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            jumpDeathCollisionBox.GetComponent<BoxCollider2D>().enabled = false;
            deathCollisionBox.GetComponent<BoxCollider2D>().enabled = true;

            isJumping = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GameOver")
        {
            counter.GetComponent<Counter>().Lose();
        }
    }
}
