/*
 * Luke Alcazar
 * GameEvent.cs
 * Project 2
 * Handles the restart on a game over
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEvent : MonoBehaviour
{
    public static int timer = 180;
    public static bool gameOver = false;
    public static bool restart = false;

    public GameObject pause;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            restart = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            gameOver = false;
            timer = 180;
            restart = false;
            
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pause.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pause.SetActive(false);
            }
        }
    }

}
