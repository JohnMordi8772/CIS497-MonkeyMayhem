using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, ISubject
{
    private Animator anim;

    private bool moved = false;

    private List<IObserver> observers = new List<IObserver>();

    public Camera cam;

    public void NotifyObservers()
    {
        foreach (IObserver observer in observers)
        {
            //observer.UpdateData(transform.position, cam.transform.forward);
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
        //observer.UpdateData(transform.position, cam.transform.forward);
    }

    public void RemoveObserver(IObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        anim = transform.Find("MrMo_A").GetComponent<Animator>();
        cam = transform.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        moved = false;

        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(Vector3.left * 10 * Time.deltaTime);
            moved = true;
            NotifyObservers();
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(Vector3.back * 10 * Time.deltaTime);
            moved = true;
            NotifyObservers();
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Vector3.right * 10 * Time.deltaTime);
            moved = true;
            NotifyObservers();
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector3.forward * 10 * Time.deltaTime);
            moved = true;
            NotifyObservers();
        }

        if (moved != anim.GetBool("moved"))
        {
            anim.SetBool("moved", moved);
        }


    }
}
