/*
 * Ashton Lively
 * MeatItem.cs
 * Project 2
 * Sets up particles when meat items are destroyed.
 */
using UnityEngine;

public class MeatItem : ParticleBehavior
{
    public override void InstantiateParticles(Vector3 pos, GameObject obj)
    {
        ParticleSystem meat = Resources.Load<ParticleSystem>("Particle Systems/Meat Particles");

        ParticleSystem ps = Instantiate(meat, pos, Quaternion.identity);

        Destroy(ps.gameObject, ps.GetComponent<ParticleSystem>().main.duration);
        Destroy(obj, ps.GetComponent<ParticleSystem>().main.duration);
    }
}
