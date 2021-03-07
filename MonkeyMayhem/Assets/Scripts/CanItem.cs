/*
 * Ashton Lively
 * CanItem.cs
 * Project 2
 * Sets up particles when can items are destroyed.
 */
using UnityEngine;

public class CanItem : ParticleBehavior
{
    public override void InstantiateParticles(Vector3 pos, GameObject obj)
    {
        ParticleSystem can = Resources.Load<ParticleSystem>("Particle Systems/Can Particles");

        ParticleSystem ps = Instantiate(can, pos, Quaternion.identity);

        Destroy(ps.gameObject, ps.GetComponent<ParticleSystem>().main.duration);
        Destroy(obj, ps.GetComponent<ParticleSystem>().main.duration);
    }
}
