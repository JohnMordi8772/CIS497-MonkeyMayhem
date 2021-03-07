/*
 * Ashton Lively
 * ShelfItem.cs
 * Project 2
 * Sets up particles when shelves are destroyed.
 */
using UnityEngine;

public class ShelfItem : ParticleBehavior
{
    public override void InstantiateParticles(Vector3 pos, GameObject obj)
    {
        obj.transform.parent.transform.Find("glass").GetComponent<Collider>().enabled = false;
        obj.transform.parent.transform.Find("glass").GetComponent<MeshRenderer>().enabled = false;

        GameObject shelf = Resources.Load<GameObject>("Particle Systems/Shelf Particles");
        Debug.Log(shelf.name);

        GameObject ps = Instantiate(shelf, pos, Quaternion.identity);

        Destroy(ps.transform.parent, ps.transform.Find("Particle System").GetComponent<ParticleSystem>().main.duration);
        Destroy(obj, ps.transform.Find("Particle System").GetComponent<ParticleSystem>().main.duration);
    }
}
