/*
 * Ashton Lively
 * HardItem.cs
 * Project 2
 * Sets up the hard physic material used on the destructible object. 
 */
using UnityEngine;

public class HardItem : PhysicsBehavior
{
    public override void UpdatePhysicMaterial(GameObject obj)
    {
        PhysicMaterial pm = Resources.Load<PhysicMaterial>("Physic Materials/Hard");

        obj.GetComponent<Collider>().material = pm;
    }
}
