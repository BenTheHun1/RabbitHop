using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject curHat;
    public GameObject player;
    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (curHat != null)
        {
            curHat.transform.Rotate(0.0f, 0.0f, (turnSpeed * Time.deltaTime), Space.Self);
        }


        if (Input.GetKeyDown(KeyCode.Space) && curHat != null)
        {
            player.transform.parent = null;
            player.GetComponent<Rigidbody>().useGravity = true;
            player.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 20, ForceMode.Impulse);
            player.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.back * 20, ForceMode.Impulse);
            curHat = null;
        }
    }
}
