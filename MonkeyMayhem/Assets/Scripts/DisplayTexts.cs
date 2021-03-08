﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayTexts : MonoBehaviour
{

    public GameObject player;
    public Text scoreTextbox;
    public Text timerTextbox;

    void Start()
    {
        StartCoroutine("countdown");
        scoreTextbox.text = "Score: 0";
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameEvent.gameOver == false) { scoreTextbox.text = "Goal: 50000\nScore: " + player.GetComponent<PlayerController>().score.totalPoints; }
            
        

        if(player.GetComponent<PlayerController>().score.totalPoints > 50000)
        {
            GameEvent.gameOver = true;
            timerTextbox.text = "Game Over! Press R to restart! You Win!!";
        }


        if (GameEvent.restart == true)
        {
            StartCoroutine("Countdown");
            player.GetComponent<PlayerController>().score.totalPoints = 0;
        }
    }


    public IEnumerator countdown()
    {
        while (GameEvent.timer >= 0 && !GameEvent.gameOver)
        {
            GameEvent.timer--;
            timerTextbox.text = "TIME: " + GameEvent.timer;

            if (GameEvent.timer > 0)
            {
                yield return new WaitForSeconds(1);
            }
            else if (GameEvent.timer == 0)
            {
                GameEvent.gameOver = true;
                timerTextbox.text = "Game Over. Press R to restart. You Lose!";
                
                yield break;
            }
        }
    }
}
