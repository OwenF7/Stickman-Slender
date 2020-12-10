using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCoinGeneral : MonoBehaviour
{
    public GameObject coin;

    public GameObject mainCamera;
    public GameObject counter;

    public float rotateSpeed = 100;

    public Transform TopBoundary;
    public Transform BottomBoundary;
    public float positionSpeed;

    bool isMovingUp; 

    public Color colorPurple = Color.magenta;
    public Color colorYellow = Color.yellow;
    public Color colorBlue = Color.blue;
    public Color colorGreen = Color.green;
    public Color colorRed = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;

        //TopBoundary = gameObject.Find("TopBoundary").transform;
        //BottomBoundary = gameObject.Find("BottomBoundary").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate Coin
        coin.transform.eulerAngles += Vector3.up * rotateSpeed * Time.deltaTime;

        // Translate Coin
        if (isMovingUp)
        {
            MoveCoinUp();
        }

        else
        {
            MoveCoinDown();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Stickman")
        {

            if (this.gameObject.tag == "Green")
            {
                mainCamera.GetComponent<Camera>().backgroundColor = colorGreen;

                //Debug.Log("+1");

                AddOnePoint();

                Destroy(coin);
            }

            if (this.gameObject.tag == "Red")
            {
                mainCamera.GetComponent<Camera>().backgroundColor = colorRed;

                //Debug.Log("+1");

                AddOnePoint();

                Destroy(coin);
            }

            if (this.gameObject.tag == "Blue")
            {
                mainCamera.GetComponent<Camera>().backgroundColor = colorBlue;

                //Debug.Log("+1");

                AddOnePoint();

                Destroy(coin);
            }

            if (this.gameObject.tag == "Yellow")
            {
                mainCamera.GetComponent<Camera>().backgroundColor = colorYellow;

                //Debug.Log("+1");

                AddOnePoint();

                Destroy(coin);
            }

            if (this.gameObject.tag == "Purple")
            {
                mainCamera.GetComponent<Camera>().backgroundColor = colorPurple;

                //Debug.Log("+1");

                AddOnePoint();

                Destroy(coin);
            }
        }
    }

    void MoveCoinUp ()
    {
        transform.Translate(Vector3.up * positionSpeed * Time.deltaTime);

        if (transform.position.y > TopBoundary.position.y)
        {
            isMovingUp = false;
        }
    }

    void MoveCoinDown ()
    {
        transform.Translate(Vector3.down * positionSpeed * Time.deltaTime);

        if (transform.position.y < BottomBoundary.position.y)
        {
            isMovingUp = true;
        }
    }

    public void AddOnePoint()
    {
        counter.GetComponent<Counter>().currentCoinsCollected += 1;
    }

}
