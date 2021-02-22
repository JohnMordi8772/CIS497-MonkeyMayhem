using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{
    [Tooltip("Material for particle system.")]
    public Material particleMaterial;

    [Tooltip("Particle system when destroyed.")]
    public ParticleSystem particleSystem;

    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check for player collision
        if (other.gameObject.tag == "Player")
        {
            // IF this code is moved to monkey collision, the following 
            gameObject.GetComponent<MeshCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;

            // Spawn particle system
            ParticleSystem particles = Instantiate(particleSystem, transform.position, Quaternion.LookRotation(player.transform.position));
            if (particles.GetComponent<ParticleSystemRenderer>().material == null)
                particles.GetComponent<ParticleSystemRenderer>().material = particleMaterial;

            // Destroy particles
            Destroy(particles, particles.startLifetime);

            // Destroy object
            Destroy(gameObject, particles.startLifetime);
        }
    }
}
