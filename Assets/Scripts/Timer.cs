using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public bool playing;
    private float timer;

    public int minutes;
    public int seconds;
    public int milliseconds;

    public int totalMilliseconds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playing == true)
        {
            timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            int milliseconds = Mathf.FloorToInt((timer * 100f) % 100f);
            //int totalMilliseconds = Mathf.FloorToInt(timer * 100f);


            timerText.text = "Current Time: " + minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
        }
    }

    // variable for total seconds 
    // total milliseconds = minutes convert to milliseconds 
    // total milliseconds = total milliseconds + seconds convert to milliseconds 
    // total milliseconds = total milliseconds + milliseconds 
    // if current total milliseconds < high total milliseconds = Update 

    // 
}
