using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour, IObserver
{
    [Tooltip("Material for particle system.")]
    public Material particleMaterial;

    [Tooltip("Particle system when destroyed.")]
    public ParticleSystem particleSystem;

    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        player.GetComponent<PlayerController>().RegisterObserver(this);
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

            // Remove from observers list 
            player.GetComponent<PlayerController>().RemoveObserver(this);

            // Destroy particles
            Destroy(particles, particles.startLifetime);

            // Destroy object
            Destroy(gameObject, particles.startLifetime);
        }
    }

    [Tooltip("Distance player has to be to object to activate physics.")]
    public float physicsEnabledDistance = 2f;

    public void UpdateData(Vector3 playerPos, Vector3 cameraDirection)
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerPos);

        if (distanceToPlayer <= physicsEnabledDistance)
        {
            if (GetComponent<Collider>().enabled == false)
                GetComponent<Collider>().enabled = true;
        }
        else
        {
            if (GetComponent<Collider>().enabled == true)
                GetComponent<Collider>().enabled = false;
        }

        // Debug.Log(Vector3.Angle(cameraDirection, transform.position));
    }
}
