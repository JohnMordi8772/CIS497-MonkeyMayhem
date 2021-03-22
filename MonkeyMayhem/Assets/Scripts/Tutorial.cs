/*
 * John Mordi
 * Tutorial.cs
 * Project 2
 * Plays tutorial audio when game starts
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public AudioSource tutorialClips;
    public DisplayTexts displayTexts;
    public GameObject[] walls;
    public AudioClip[] audioClips;

    // Start is called before the first frame update
    void Start()
    {
        tutorialClips.pitch = 1f;
        tutorialClips.Play();
        StartCoroutine(TutorialManager());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TutorialManager()
    {
        yield return new WaitForSeconds(tutorialClips.clip.length + 1);
        Destroy(walls[0]);

        tutorialClips.PlayOneShot(audioClips[0]);
        yield return new WaitForSeconds(audioClips[0].length);
        Destroy(walls[1]);

        tutorialClips.PlayOneShot(audioClips[1]);
        yield return new WaitForSeconds(audioClips[1].length);
        Destroy(walls[2]);

        tutorialClips.PlayOneShot(audioClips[2]);
        yield return new WaitForSeconds(audioClips[2].length);
        Destroy(walls[3]);

        StartCoroutine(displayTexts.Countdown());


        yield break;
    }
}
