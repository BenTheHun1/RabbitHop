using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject curHat;
    public GameObject player;
    public float turnSpeed;
    public float force;

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

        //Debug.Log(player.transform.localPosition);
        if (Input.GetKeyDown(KeyCode.Space) && curHat != null)
        {
            player.GetComponent<Rigidbody>().useGravity = true;
            player.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * force, ForceMode.Impulse);
            player.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.back * force, ForceMode.Impulse);
            player.transform.parent = null;
            player.transform.localScale = new Vector3(1, 1, 1);
            curHat = null;
        }
    }
}
