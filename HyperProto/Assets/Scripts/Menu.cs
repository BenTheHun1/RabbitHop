using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Menu : MonoBehaviour
{
    public Text displayHighScore;
	public Text displayVersionNumber;

	public GameObject Instructions;
	public Text storyText;

	public List<string> story;
	public Animator animator;
	public int storyStep;

	public Button continueStory;
	public Button backStory;

	public AudioSource storyAudio;
	public List<AudioClip> audioClips;


	public Button quitGame;
    void Start()
    {
		if (SystemInfo.deviceType == DeviceType.Desktop && Application.platform == RuntimePlatform.WindowsPlayer)
		{
			quitGame.gameObject.SetActive(true);
		}
		else
		{
			quitGame.gameObject.SetActive(false);
		}
			Instructions.SetActive(false);
		storyStep = 1;
        TimeSpan time = TimeSpan.FromSeconds(PlayerPrefs.GetFloat("record"));
		if (time.TotalSeconds > 0)
		{
			displayHighScore.text = "High Score: " + time.ToString(@"mm\:ss\.ff");
		}
		else
		{
			displayHighScore.text = "";
		}
			displayVersionNumber.text = Application.version;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

	public void QuitGame()
	{
		Application.Quit();
	}

	public void InstructionsToggle()
	{
		Instructions.SetActive(!Instructions.activeSelf);
		if (Instructions.activeSelf == true)
		{
			storyStep = 0;
			ContinueInstructions(true);
		}
	}

	public void ContinueInstructions(bool isForward)
	{
		if (isForward)
		{
			storyStep++;
		}
		else
		{
			storyStep--;
		}
		
		animator.SetInteger("step", storyStep);
		storyText.text = story[storyStep];

		if (audioClips[storyStep] != null)
		{
			storyAudio.PlayOneShot(audioClips[storyStep]);
		}
		else
		{
			storyAudio.Stop();
		}

		if (storyStep == 1)
		{
			backStory.gameObject.SetActive(false);
		}
		else
		{
			backStory.gameObject.SetActive(true);
		}

		if (storyStep == 7)
		{
			continueStory.gameObject.SetActive(false);
		}
		else
		{
			continueStory.gameObject.SetActive(true);
		}
	}
}
