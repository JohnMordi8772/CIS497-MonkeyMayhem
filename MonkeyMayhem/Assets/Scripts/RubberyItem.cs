/*
 * Ashton Lively
 * RubberyItem.cs
 * Project 2
 * Sets up the rubbery physic material used on the destructible object. 
 */
using UnityEngine;

public class RubberyItem : PhysicsBehavior
{
    public override void UpdatePhysicMaterial(GameObject obj)
    {
        PhysicMaterial pm = Resources.Load<PhysicMaterial>("Physic Materials/Rubbery");

        obj.GetComponent<Collider>().material = pm;
    }
}