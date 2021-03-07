/*
 * Ashton Lively
 * BreadItem.cs
 * Project 2
 * Sets up particles when bread items are destroyed.
 */
using UnityEngine;

public class BreadItem : ParticleBehavior
{
    public override void InstantiateParticles(Vector3 pos, GameObject obj)
    {
        ParticleSystem bread = Resources.Load<ParticleSystem>("Particle Systems/Bread Particles");

        ParticleSystem ps = Instantiate(bread, pos, Quaternion.identity);

        Destroy(ps.gameObject, ps.GetComponent<ParticleSystem>().main.duration);
        Destroy(obj, ps.GetComponent<ParticleSystem>().main.duration);
    }
}
