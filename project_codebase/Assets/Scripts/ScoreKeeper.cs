using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    private int totalScore;
    public int scoreThreshold;
    public Transform coinSpawnLoc;
    public Transform coin;
    public TextMeshProUGUI outputScore;

    public GameObject endCanvas;
    public TextMeshProUGUI endScore;
    public TextMeshProUGUI threshold;
    public TextMeshProUGUI passText;
    public TextMeshProUGUI failText;

    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        endCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scoreUp(int addScore)
    {
        totalScore += addScore;
        for (int count = 0; count < addScore; count++)
        {
            Instantiate(coin, coinSpawnLoc.position, coinSpawnLoc.rotation);
        }
        int dollars = (totalScore * 10) / 100;
        int cents = (totalScore * 10) % 100;
        string doll_str = dollars.ToString("00");
        string cents_str = cents.ToString("00");

        outputScore.text = ("$" + doll_str + "." + cents_str);
    }

    public int getScore()
    {
        return totalScore;
    }

    public void gameOver()
    {
        endCanvas.SetActive(true);
        int dollars = (totalScore * 10) / 100;
        int cents = (totalScore * 10) % 100;
        string doll_str = dollars.ToString("00");
        string cents_str = cents.ToString("00");

        endScore.text = ("$" + doll_str + "." + cents_str);

        dollars = (scoreThreshold * 10) / 100;
        cents = (scoreThreshold * 10) % 100;
        doll_str = dollars.ToString("00");
        cents_str = cents.ToString("00");

        threshold.text = ("$" + doll_str + "." + cents_str);

        if (totalScore >= scoreThreshold)
        {
            passText.text = "You passed!";
        }
        else
        {
            failText.text = "You failed.";
        }
    }
}
