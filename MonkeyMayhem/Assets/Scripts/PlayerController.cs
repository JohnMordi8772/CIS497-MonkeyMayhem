using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, ISubject
{
    private Animator anim;
    private bool moved = false;
    private List<IObserver> observers = new List<IObserver>();
    public Camera cam;
    public AudioSource monkeyAudioPlayer;
    public AudioClip[] monkeySounds;
    public AudioSource backGroundMusic;
    private bool mime = false;
    public Score score;

    public void NotifyObservers()
    {
        foreach (IObserver observer in observers)
        {
           observer.UpdateData(transform.position);
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
       observer.UpdateData(transform.position);
    }

    public void RemoveObserver(IObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    public void MimeStatus()
    {
        if(mime)
        {
            mime = false;
            gameObject.tag = "Player";
        }
        else
        {
            mime = true;
            gameObject.tag = "Mime";
        }
    }

    public void MimePowerUpAct()
    {
        StartCoroutine(MimePowerUp());
    }

    private IEnumerator MimePowerUp()
    {
        MimeStatus();
        backGroundMusic.Stop();
        backGroundMusic.PlayOneShot(monkeySounds[9]);
        gameObject.GetComponent<Collider>().isTrigger = true;
        gameObject.GetComponent<Rigidbody>().useGravity = false;

        yield return new WaitForSeconds(30);

        MimeStatus();
        gameObject.GetComponent<Collider>().isTrigger = false;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        backGroundMusic.Stop();
        backGroundMusic.Play();

        yield break;
    }

    

    // Start is called before the first frame update
    void Awake()
    {
        anim = transform.Find("MrMo_A").GetComponent<Animator>();
        score = new Score();
        cam = transform.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        moved = false;

        if (Input.GetKey(KeyCode.W) && !GameEvent.gameOver)
        {
            gameObject.transform.Translate(Vector3.left * 20 * Time.deltaTime);
            moved = true;
            NotifyObservers();
        }
        if (Input.GetKey(KeyCode.A) && !GameEvent.gameOver)
        {
            gameObject.transform.Translate(Vector3.back * 20 * Time.deltaTime);
            moved = true;
            NotifyObservers();
        }
        if (Input.GetKey(KeyCode.S) && !GameEvent.gameOver)
        {
            gameObject.transform.Translate(Vector3.right * 20 * Time.deltaTime);
            moved = true;
            NotifyObservers();
        }
        if (Input.GetKey(KeyCode.D) && !GameEvent.gameOver)
        {
            gameObject.transform.Translate(Vector3.forward * 20 * Time.deltaTime);
            moved = true;
            NotifyObservers();
        }
        if(Input.GetKeyDown(KeyCode.Q) && !GameEvent.gameOver)
        {
            monkeyAudioPlayer.pitch = 1f;
            monkeyAudioPlayer.PlayOneShot(monkeySounds[Random.Range(0,7)]);
            //monkeySound.PlayOneShot(monkeySound.clip);
        }

        if (moved != anim.GetBool("moved"))
        {
            anim.SetBool("moved", moved);
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Produce"))
        {
            score = new Produce(score);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Containers"))
        {
            score = new Containers(score);
            
        }
    }
}
