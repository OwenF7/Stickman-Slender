using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorCoinGreen : MonoBehaviour
{
    public GameObject coin;
    public GameObject mainCamera;
    public GameObject counter;

    public float rotateSpeed = 100;


    public Color colorGreen = Color.green;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate Coin
        coin.transform.eulerAngles += Vector3.up * rotateSpeed * Time.deltaTime;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Stickman")
        {
            mainCamera.GetComponent<Camera>().backgroundColor = colorGreen;

            //Debug.Log("+1");

            AddOnePoint();

            Destroy(coin);
        }
    }

    public void AddOnePoint()
    {
        counter.GetComponent<Counter>().currentCoinsCollected += 1;
    }
}
