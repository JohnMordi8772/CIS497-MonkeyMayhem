/*
 * John Mordi
 * MimeOutfit.cs
 * Project 2
 * Ensures mime powerup goes into effect
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimeOutfit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.gameObject.GetComponent<PlayerController>().MimePowerUpAct();
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
