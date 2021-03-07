/*
 * Ashton Lively
 * FruitItem.cs
 * Project 2
 * Sets up particles when fruit items are destroyed.
 */
using UnityEngine;

public class FruitItem : ParticleBehavior
{
    public override void InstantiateParticles(Vector3 pos, GameObject obj)
    {
        ParticleSystem fruit = Resources.Load<ParticleSystem>("Particle Systems/Onion Particles");

        ParticleSystem ps = Instantiate(fruit, pos, Quaternion.identity);
        ps.GetComponent<ParticleSystemRenderer>().material = obj.GetComponent<Renderer>().material;

        Destroy(ps.gameObject, ps.GetComponent<ParticleSystem>().main.duration);
        Destroy(obj, ps.GetComponent<ParticleSystem>().main.duration);
    }
}
