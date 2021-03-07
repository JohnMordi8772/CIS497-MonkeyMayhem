/*
 * Ashton Lively
 * DestructableObject.cs
 * Project 2
 * Properties and behaviors of destructable objects
 */
using UnityEngine;

public class DestructableObject : MonoBehaviour, IObserver
{
    public enum ItemType { BREAD, CAN, CHEESE, FRUIT, LIQUID, MEAT} 
    public ItemType itemType;

    public enum ItemDensity { HARD, HEAVY, SOFT, RUBBERY }
    public ItemDensity itemDensity;
    
    private GameObject player;

    private void Start()
    {
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
            gameObject.GetComponent<Collider>().enabled = false;

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
            }

            pb.InstantiateParticles(transform.position, this.gameObject);
        }
    }

    [Tooltip("Distance player has to be to object to activate physics.")]
    public float physicsEnabledDistance = 2f;

    public void UpdateData(Vector3 playerPos, Vector3 cameraDirection)
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerPos);

        if (distanceToPlayer <= physicsEnabledDistance)
        {
            if (GetComponent<Collider>().enabled == false)
                GetComponent<Collider>().enabled = true;
        }
        else
        {
            if (GetComponent<Collider>().enabled == true)
                GetComponent<Collider>().enabled = false;
        }

        // Debug.Log(Vector3.Angle(cameraDirection, transform.position));
    }
}
