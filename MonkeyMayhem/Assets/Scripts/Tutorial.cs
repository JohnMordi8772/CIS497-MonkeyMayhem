using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public AudioSource tutorialClips;

    // Start is called before the first frame update
    void Start()
    {
        tutorialClips.pitch = 1f;
        tutorialClips.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
