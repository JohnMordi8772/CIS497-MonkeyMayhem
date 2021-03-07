/*
 * Ashton Lively
 * CheeseItem.cs
 * Project 2
 * Sets up particles when cheese items are destroyed.
 */
using UnityEngine;

public class CheeseItem : ParticleBehavior
{
    public override void InstantiateParticles(Vector3 pos, GameObject obj)
    {
        ParticleSystem cheese = Resources.Load<ParticleSystem>("Particle Systems/Cheese Particles");

        ParticleSystem ps = Instantiate(cheese, pos, Quaternion.identity);

        Destroy(ps.gameObject, ps.GetComponent<ParticleSystem>().main.duration);
        Destroy(obj, ps.GetComponent<ParticleSystem>().main.duration);
    }
}
