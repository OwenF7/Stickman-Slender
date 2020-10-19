using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanMove : MonoBehaviour
{

    public GameObject stickman;
    public GameObject jumpCollider;

    public Sprite stand;
    public Sprite walk1;
    public Sprite walk2;
    public Sprite walk3;
    public Sprite walk4;
    public Sprite walk5;
    public Sprite walk6;
    public Sprite walk7;
    public Sprite jump;

    public int faceDirection = 0;
    public int walkImage = 1;

    public float speed = 5;
    public float jumpHeight = 300;

    public float delay;
    public float delayReset = 1;

    public bool isWalking = false;
    public bool isJumping = false; 

    // Start is called before the first frame update
    void Start()
    {
        delay = delayReset;

        stickman.GetComponent<BoxCollider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        delay -= 1 * Time.deltaTime;

        if (delay <= 0)
        {
            if (isWalking == true)
            {
                Walk();
            }

            delay = delayReset;
        }

        if (isJumping == true)
        {
            stickman.GetComponent<SpriteRenderer>().sprite = jump;

            stickman.GetComponent<BoxCollider2D>().enabled = false;
        }

        else if (isJumping == false)
        {
            stickman.GetComponent<BoxCollider2D>().enabled = true;
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            stickman.transform.Translate(Vector3.right * speed * Time.deltaTime);
            isWalking = true;
            faceDirection = 0;
            Direction();
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            stickman.transform.Translate(Vector3.left * speed * Time.deltaTime);
            isWalking = true;
            faceDirection = 1;
            Direction();
        }

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            if (isJumping != true)
            {
                stickman.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
                isJumping = true;
            }

        }

        if (Input.GetKey(KeyCode.RightArrow) != true && Input.GetKey(KeyCode.LeftArrow) != true && isJumping != true)
        {
            stickman.GetComponent<SpriteRenderer>().sprite = stand;
            isWalking = false;
        }
    }

    public void Walk()
    {
        if (walkImage == 1)
        {
            stickman.GetComponent<SpriteRenderer>().sprite = walk1;
            walkImage = 2;
            delay = delayReset;
        }

        else if (walkImage == 2)
        {
            stickman.GetComponent<SpriteRenderer>().sprite = walk2;
            walkImage = 3;
            delay = delayReset;
        }

        else if (walkImage == 3)
        {
            stickman.GetComponent<SpriteRenderer>().sprite = walk3;
            walkImage = 4;
            delay = delayReset;
        }

        else if (walkImage == 4)
        {
            stickman.GetComponent<SpriteRenderer>().sprite = walk4;
            walkImage = 5;
            delay = delayReset;
        }

        else if (walkImage == 5)
        {
            stickman.GetComponent<SpriteRenderer>().sprite = walk5;
            walkImage = 6;
            delay = delayReset;
        }

        else if (walkImage == 6)
        {
            stickman.GetComponent<SpriteRenderer>().sprite = walk6;
            walkImage = 7;
            delay = delayReset;
        }

        else
        {
            stickman.GetComponent<SpriteRenderer>().sprite = walk7;
            walkImage = 1;
            delay = delayReset;
        }
    }

    public void Direction()
    {
        if (stickman.transform.localScale.x < 0) // Left Facing
        {
            if (faceDirection == 0)
            {
                stickman.transform.localScale = new Vector3(stickman.transform.localScale.x * -1, stickman.transform.localScale.y, stickman.transform.localScale.z);
            }
        }

        if (stickman.transform.localScale.x > 0) // Right Facing
        {
            if (faceDirection == 1)
            {
                stickman.transform.localScale = new Vector3(stickman.transform.localScale.x * -1, stickman.transform.localScale.y, stickman.transform.localScale.z);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isJumping = false;
        }
    }
}
