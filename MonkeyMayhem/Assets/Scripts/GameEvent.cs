using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEvent : MonoBehaviour
{
    public static int timer;
    public static bool gameOver;

    private void Start()
    {
        timer = 180;
        gameOver = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
