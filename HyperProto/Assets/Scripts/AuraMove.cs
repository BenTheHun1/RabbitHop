using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraMove : MonoBehaviour
{

    public int speed;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        gm.magician.transform.position = (new Vector3(gm.magician.transform.position.x, gm.player.transform.position.y, 0));
    }
}
