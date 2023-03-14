using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip jump;
    public AudioClip land;
    public AudioClip carrot;
    public GameManager gm;

    public GameObject earL;
    public GameObject earR;

    // Start is called before the first frame update
    void Start()
    {
        if (true)
        {
            earL.transform.localScale = new Vector3(0.4f, 1.1f, 0.4f);
            earR.transform.localScale = new Vector3(0.4f, 1.1f, 0.4f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hat"))
        {
            audioSource.PlayOneShot(land);
            gameObject.transform.parent = other.gameObject.transform;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            gameObject.transform.localPosition = new Vector3(0f, 0f, 0.55f);
            gameObject.transform.localEulerAngles = new Vector3(0f, 90f, 90f);
            gameObject.transform.localScale = new Vector3(0.33f, 0.33f, 0.33f);
            gm.curHat = other.gameObject;
        }
        else if (other.gameObject.CompareTag("death"))
        {
            gm.EndGame();
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("speed"))
        {
            audioSource.PlayOneShot(carrot);
            gm.SpeedUp();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("finish"))
        {
            gm.Finish();
        }

    }
}
