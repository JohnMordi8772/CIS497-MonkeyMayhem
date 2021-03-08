/*
 * Ashton Lively
 * DestructableObject.cs
 * Project 2
 * Properties and behaviors of destructable objects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour, IObserver
{
    public enum ItemType { BREAD, CAN, CHEESE, FRUIT, LIQUID, MEAT, SHELF} 
    public ItemType itemType;

    public enum ItemDensity { HARD, HEAVY, SOFT, RUBBERY }
    public ItemDensity itemDensity;
    
    private GameObject player;

    List<GameObject> colliderItems = new List<GameObject>();
    Transform[] children;

    private void Start()
    {
        children = gameObject.GetComponentsInChildren<Transform>();

        if (gameObject.GetComponent<Collider>() == true)
        {
            colliderItems.Add(gameObject);
        }
        foreach (Transform obj in children)
        {
            if (obj.gameObject.GetComponent<Collider>() == true)
            {
                colliderItems.Add(obj.gameObject);
            }
        }

        player = GameObject.Find("Player");
        player.GetComponent<PlayerController>().RegisterObserver(this);

        PhysicsBehavior phys = null;

        switch (itemDensity)
        {
            case ItemDensity.HARD:
                phys = new HardItem();
                break;
            case ItemDensity.HEAVY:
                phys = new HeavyItem();
                break;
            case ItemDensity.SOFT:
                phys = new SoftItem();
                break;
            case ItemDensity.RUBBERY:
                phys = new RubberyItem();
                break;
        }
        phys.UpdatePhysicMaterial(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check for player collision
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerController>().RemoveObserver(this);

            Collider[] colliders = gameObject.GetComponents<Collider>();
            foreach(Collider collider in colliders)
            {
                colliderItems.Remove(collider.gameObject);
                collider.enabled = false;
            }

            foreach (Transform child in transform)
            {
                child.GetComponent<MeshRenderer>().enabled = false;
            }

            if (gameObject.GetComponent<MeshRenderer>() != null)
                gameObject.GetComponent<MeshRenderer>().enabled = false;

            ParticleBehavior pb = null;

            switch (itemType) {
                case ItemType.BREAD:
                    pb = new BreadItem();
                    break;
                case ItemType.CAN:
                    pb = new CanItem();
                    break;
                case ItemType.CHEESE:
                    pb = new CheeseItem();
                    break;
                case ItemType.FRUIT:
                    pb = new FruitItem();
                    break;
                case ItemType.LIQUID:
                    pb = new LiquidItem();
                    break;
                case ItemType.MEAT:
                    pb = new MeatItem();
                    break;
                case ItemType.SHELF:
                    pb = new ShelfItem();
                    break;
            }

            if (gameObject.transform.parent == true)
                pb.InstantiateParticles(collision.contacts[0].point, gameObject.transform.parent.gameObject);
            else
                pb.InstantiateParticles(collision.contacts[0].point, gameObject);

        }
    }

    [Tooltip("Distance player has to be to object to activate physics.")]
    private float physicsEnabledDistance = 1000f;

    public void UpdateData(Vector3 playerPos)
    {
        float distanceToPlayer = Mathf.Abs(Vector3.Distance(transform.position, playerPos));

        if (distanceToPlayer <= physicsEnabledDistance)
        {
            foreach (GameObject obj in colliderItems)
            {
                if (obj == true)
                {
                    obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    obj.GetComponent<Collider>().enabled = true;
                }
                
            }
        }
        else if (distanceToPlayer >= physicsEnabledDistance)
        {
            Debug.Log(distanceToPlayer);
            foreach (GameObject obj in colliderItems)
            {
                if (obj == true)
                {
                    obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    obj.GetComponent<Collider>().enabled = false;
                }
                
            }
        }
    }
}
