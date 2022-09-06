using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Timer : MonoBehaviour
{
    bool active = false;
    float currentTime;
    public Text txt;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            currentTime += Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        txt.text = time.ToString(@"mm\:ss\.ff");
    }

}
