using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform cameraFollow;

    private Vector3 smoothPosition;
    public float smoothSpeed = 0.5f;

    public AudioSource minotaurTapping;
    public AudioSource adventureTapping;


    // Start is called before the first frame update
    void Start()
    {
        adventureTapping.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        smoothPosition = Vector3.Lerp(this.transform.position, new Vector3(cameraFollow.position.x, cameraFollow.position.y, this.transform.position.z), smoothSpeed);
        this.transform.position = smoothPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Minotaur")
        {
            adventureTapping.Stop();
            minotaurTapping.Play(); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Minotaur")
        {
            adventureTapping.Play();
            minotaurTapping.Stop();
        }
    }
}
