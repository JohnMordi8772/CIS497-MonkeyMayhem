using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeMan : MonoBehaviour
{
    public AudioSource boingSource;
    private void OnCollisionEnter(Collision collision)
    {
        float x = 20f, z = 20f;
        float dirForceX = collision.collider.gameObject.transform.position.x - gameObject.transform.position.x;
        float dirForceZ = collision.collider.gameObject.transform.position.z - gameObject.transform.position.z;
        x = x * (dirForceX / Mathf.Abs(dirForceX));
        z = z * (dirForceZ / Mathf.Abs(dirForceZ));
        collision.collider.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(x, 0, z), ForceMode.Impulse);
        boingSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
