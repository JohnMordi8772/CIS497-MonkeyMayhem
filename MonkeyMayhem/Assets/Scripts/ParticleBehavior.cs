/*
 * Ashton Lively
 * ParticleBehavior.cs
 * Project 2
 * Sets up particles when items are destroyed.
 */
using UnityEngine;

public abstract class ParticleBehavior : MonoBehaviour
{
    public abstract void InstantiateParticles(Vector3 pos, GameObject obj);
}
