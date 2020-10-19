using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    public GameObject counter;
    public GameObject timer; 

    public GameObject inGameUI;
    public GameObject gameOverUI;
    public GameObject victoryUI;

    public Text coinsCollected;
    public int currentCoinsCollected = 0;

    //public Text bestTimeText; 

    // Start is called before the first frame update
    private void Start()
    {
        //float besttime = PlayerPrefs.GetFloat("bestTime", 0);
        //bestTimeText.text = "Best Time: " + besttime.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        coinsCollected.text = "Coins " + currentCoinsCollected.ToString() + " of 5";

        if (currentCoinsCollected >= 5)
        {
            timer.GetComponent<Timer>().playing = false;
            victoryUI.SetActive(true);
            Time.timeScale = 0;

            //float besttime = PlayerPrefs.GetFloat("bestTime", 0);

            //if (timer.GetComponent<Timer>().minutes >)
        }
    }

    public void OnRestartButtonPressed()
    {
        SceneManager.LoadScene("SampleScene");

        Time.timeScale = 1;
    }
}
