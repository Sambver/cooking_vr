using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Timer : MonoBehaviour
{
    private int startTime;
    public int timeLimit = 60; // Seconds in level
    public Text countdown_text;
    public GameObject gameElements;
    public AudioSource alarm;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CountDown");
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLimit >= 0)
        {
            //countdown_text.text = ("" + timeLimit);
            int minutes = timeLimit / 60;
            int seconds = timeLimit % 60;
            string minutes_str = minutes.ToString("00");
            string seconds_str = seconds.ToString("00");

            countdown_text.text = ("" + minutes_str + ":" + seconds_str);
        } 
        if (timeLimit <= 0)
        {
            gameElements.GetComponent<ScoreKeeper>().gameOver();
            gameElements.GetComponent<OrderManager>().endAll();
            alarm.Play();
            timeLimit = -5;
        }
        
    }

    IEnumerator CountDown()
    {
        while (timeLimit > -1)
        {
            yield return new WaitForSeconds(1);
            timeLimit--;
        }
    }
}
