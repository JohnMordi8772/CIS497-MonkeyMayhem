/*
 * Ashton Lively
 * HeavyItem.cs
 * Project 2
 * Sets up the heavy physic material used on the destructible object. 
 */
using UnityEngine;

public class HeavyItem : PhysicsBehavior
{
    public override void UpdatePhysicMaterial(GameObject obj)
    {
        PhysicMaterial pm = Resources.Load<PhysicMaterial>("Physic Materials/Heavy");

        obj.GetComponent<Collider>().material = pm;
    }
}
