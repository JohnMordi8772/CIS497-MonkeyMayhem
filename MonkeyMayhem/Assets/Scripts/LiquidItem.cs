/*
 * Ashton Lively
 * LiquidItem.cs
 * Project 2
 * Sets up particles when liquid items are destroyed.
 */
using UnityEngine;

public class LiquidItem : ParticleBehavior
{
    public override void InstantiateParticles(Vector3 pos, GameObject obj)
    {
        ParticleSystem liquid = Resources.Load<ParticleSystem>("Particle Systems/Liquid Particles");

        ParticleSystem ps = Instantiate(liquid, pos, Quaternion.identity);
        ps.GetComponent<ParticleSystemRenderer>().material = obj.GetComponent<Renderer>().material;

        Destroy(ps.gameObject, ps.GetComponent<ParticleSystem>().main.duration);
        Destroy(obj, ps.GetComponent<ParticleSystem>().main.duration);
    }
}
