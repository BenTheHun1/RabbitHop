using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool doHard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(bool Hard)
    {
        if (Hard)
        {
            doHard = Hard;
        }
        else
        {
            doHard = false;
        }
        SceneManager.LoadScene("Main");
    }
}
