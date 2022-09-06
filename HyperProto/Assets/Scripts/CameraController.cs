using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("GameManager").GetComponent<GameManager>().dead.activeSelf)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x + 2, player.transform.position.y + 2, player.transform.position.z - 10);

        }
    }
}
