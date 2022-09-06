using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource jump;
    public AudioSource land;
    public AudioSource carrot;
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
            land.Play();
            gameObject.transform.parent = other.gameObject.transform;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            gameObject.transform.localPosition = new Vector3(0f, 1.4f, 0f);
            gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            gm.curHat = other.gameObject;
        }
        else if (other.gameObject.CompareTag("death"))
        {
            gm.EndGame();
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("speed"))
        {
            carrot.Play();
            gm.SpeedUp();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            gm.Finish();
        }

    }
}
