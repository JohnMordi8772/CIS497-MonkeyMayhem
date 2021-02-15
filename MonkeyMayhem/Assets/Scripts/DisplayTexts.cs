using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayTexts : MonoBehaviour
{
    public Text textbox1;
    public Text textbox2;
    public int timer = 10;
    public int score = 0;

    void Start()
    {
        textbox1.text = "Timer: ";
        textbox2.text = "Score: ";
    }

    // Update is called once per frame
    void Update()
    {
        textbox1.text = "Timer: " + timer;
        textbox2.text = "Score: " + score;

        timer--;
        score++;
    }
}
