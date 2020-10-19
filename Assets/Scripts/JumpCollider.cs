using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCollider : MonoBehaviour
{
    public GameObject stickman;

    public bool isJumping = false;

    public GameObject jumpCollider;

    // Start is called before the first frame update
    void Start()
    {
        jumpCollider.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            jumpCollider.GetComponent<BoxCollider2D>().enabled = true;

            isJumping = true;

        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            jumpCollider.GetComponent<BoxCollider2D>().enabled = false;

            isJumping = false;
        }
    }
}
