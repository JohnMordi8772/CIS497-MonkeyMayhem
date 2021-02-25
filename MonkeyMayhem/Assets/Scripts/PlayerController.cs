using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;

    private bool moved = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.Find("MrMo_A").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moved = false;

        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(Vector3.left * 10 * Time.deltaTime);
            moved = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(Vector3.back * 10 * Time.deltaTime);
            moved = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Vector3.right * 10 * Time.deltaTime);
            moved = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector3.forward * 10 * Time.deltaTime);
            moved = true;
        }

        if (moved != anim.GetBool("moved"))
        {
            anim.SetBool("moved", moved);
        }
    }
}
