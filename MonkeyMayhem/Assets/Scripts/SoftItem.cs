/*
 * Ashton Lively
 * SoftItem.cs
 * Project 2
 * Sets up the soft physic material used on the destructible object. 
 */
using UnityEngine;

public class SoftItem : PhysicsBehavior
{
    public override void UpdatePhysicMaterial(GameObject obj)
    {
        PhysicMaterial pm = Resources.Load<PhysicMaterial>("Physic Materials/Soft");

        obj.GetComponent<Collider>().material = pm;
    }
}
