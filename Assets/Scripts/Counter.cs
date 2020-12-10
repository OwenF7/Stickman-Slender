using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    public GameObject counter;
    public GameObject timer;
    public GameObject stickman;
    public GameObject enemy; 

    public GameObject adventureTapping;
    public GameObject monsterTapping;

    public GameObject inGameUI;
    public GameObject gameOverUI;
    public GameObject victoryUI;

    public Text coinsCollected;
    public int currentCoinsCollected = 0;

    public Text bestTimeText;

    public int besttimemin;
    public int besttimesec;
    public int besttimemil;

    public bool minEqual = false;

    //public int besttotaltimemil; 

    // Start is called before the first frame update
    private void Start()
    {
        int besttimemin = PlayerPrefs.GetInt("bestTimeMin");
        int besttimesec = PlayerPrefs.GetInt("bestTimeSec");
        int besttimemil = PlayerPrefs.GetInt("bestTimeMil");
        //int besttotaltimemil = PlayerPrefs.GetInt("totalBestTimeMil");

        bestTimeText.text = "Best Time: " + besttimemin.ToString() + ":" + besttimesec.ToString() + ":" + besttimemil.ToString();

        stickman.GetComponent<BoxCollider2D>();

        //enemy.GetComponent<BoxCollider2D>();
    }

    // Greater than or equal to is key!!! 

    // Update is called once per frame
    void Update()
    {
        coinsCollected.text = "Coins " + currentCoinsCollected.ToString() + " of 5";

        if (currentCoinsCollected >= 5)
        {
            timer.GetComponent<Timer>().playing = false;
            victoryUI.SetActive(true);

            //if (timer.GetComponent<Timer>().totalMilliseconds < besttotaltimemil)
            //{ 
                //PlayerPrefs.SetInt("bestTimeMin", timer.GetComponent<Timer>().minutes);
                //PlayerPrefs.SetInt("bestTimeSec", timer.GetComponent<Timer>().seconds);
                //PlayerPrefs.SetInt("bestTimeMil", timer.GetComponent<Timer>().milliseconds);
                //PlayerPrefs.SetInt("totalBestTimeMil", timer.GetComponent<Timer>().totalMilliseconds);

                //bestTimeText.text = "Best Time: " + besttimemin.ToString() + ":" + besttimesec.ToString() + ":" + besttimemil.ToString(); 
            //}

            if (timer.GetComponent<Timer>().minutes <= besttimemin)
            {
                if (timer.GetComponent<Timer>().minutes == besttimemin)
                {
                    if (timer.GetComponent<Timer>().seconds <= besttimesec)
                    {
                        if (timer.GetComponent<Timer>().seconds == besttimesec)
                        {
                            if (timer.GetComponent<Timer>().milliseconds < besttimemil)
                            {
                                PlayerPrefs.SetInt("bestTimeMil", timer.GetComponent<Timer>().milliseconds);
                            }
                        }

                        PlayerPrefs.SetInt("bestTimeSec", timer.GetComponent<Timer>().seconds);
                    }
                }

                PlayerPrefs.SetInt("bestTimeMin", timer.GetComponent<Timer>().minutes);
            }
        } 
    }

    public void Lose()
    {
        Debug.Log("Game Over");
        timer.GetComponent<Timer>().playing = false;
        gameOverUI.SetActive(true);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
