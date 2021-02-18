using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayTexts : MonoBehaviour
{
    public Text scoreTextbox;
    public Text timerTextbox;
    public int timer = 20;
    public int score = 0;

    void Start()
    {
        scoreTextbox.text = "Score: ";
        StartCoroutine("countdown");
    }

    // Update is called once per frame
    void Update()
    {
        scoreTextbox.text = "Score: " + score;
    }

    public IEnumerator countdown()
    {
        while(timer >= 0)
        {
            timer--;
            timerTextbox.text = "TIME: " + timer;

            if(timer > 0)
            {
                yield return new WaitForSeconds(1);
            }else if(timer == 0){
                timerTextbox.text = "Game Over";
                yield break;
            }
        }
    }

}
