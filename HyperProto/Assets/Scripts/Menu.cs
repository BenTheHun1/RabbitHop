using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Menu : MonoBehaviour
{
    public static bool doHard;
    public Text displayHighScore;
	public Text displayVersionNumber;

    // Start is called before the first frame update
    void Start()
    {
        TimeSpan time = TimeSpan.FromSeconds(PlayerPrefs.GetFloat("record"));
		if (time.TotalSeconds > 0)
		{
			displayHighScore.text = "High Score: " + time.ToString(@"mm\:ss\.ff");
		}
		displayVersionNumber.text = Application.version;
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
