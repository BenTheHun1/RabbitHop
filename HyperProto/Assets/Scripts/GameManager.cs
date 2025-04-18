using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;



public class GameManager : MonoBehaviour
{

    public GameObject curHat;
    public GameObject player;
    public GameObject magician;
    public float turnSpeed;
    private int speedup = 1;
    private float speeduptimer = 0;

    public GameObject pause;
    public GameObject dead;
    public GameObject win;
    public GameObject SpeedIndicator;
    public TextMeshProUGUI SpeedUpTimeIndicator;
    public float force;
    private port portType;
    public GameObject jumpButton;
	public GameObject jumpButton2;
	public enum port { pc, mobile }
    public Timer timer;

	public Slider progRabbit;
	public Slider progMagician;
	public Transform Goal;

	public Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
		startPos = player.transform.position;
		pause.SetActive(false);
        dead.SetActive(false);
        win.SetActive(false);
		progMagician.gameObject.SetActive(false);

        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            portType = port.mobile;
			Application.targetFrameRate = 60;
		}
        else
        {
            portType = port.pc;
        }

        if (portType != port.mobile)
        {
            jumpButton.SetActive(false);
			jumpButton2.SetActive(false);
		}
    }

    // Update is called once per frame
    void Update()
    {
		if (Time.timeScale == 1 && player != null)
		{
			//Debug.Log(1f - (Vector3.Distance(Goal.position, player.transform.position) / Vector3.Distance(Goal.position, startPos)));
			progRabbit.value = 1f - (Vector3.Distance(Goal.position, player.transform.position) / Vector3.Distance(Goal.position, startPos));
			if (magician.transform.position.x > startPos.x)
			{
				progMagician.gameObject.SetActive(true);
				progMagician.value = 1f - (Vector3.Distance(Goal.position, magician.transform.position) / Vector3.Distance(Goal.position, startPos));
			}
		}

        if (speeduptimer > 0) 
        {
            SpeedIndicator.SetActive(true);
            speeduptimer -= 1 * Time.deltaTime;
            SpeedUpTimeIndicator.text = speeduptimer.ToString("0");
            speedup = 2;
        }
        else
        {
            SpeedIndicator.SetActive(false);
            speedup = 1;
        }

        if (curHat != null)
        {
            curHat.transform.Rotate((turnSpeed * speedup * Time.deltaTime), 0f, 0f, Space.Self);
        }

        //Debug.Log(player.transform.localPosition);
        if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)) && portType == port.pc && Time.timeScale == 1)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Jump Ignored");
                return;
            }

            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Jump()
    {
        if (curHat != null)
        {
            player.GetComponent<PlayerController>().audioSource.PlayOneShot(player.GetComponent<PlayerController>().jump);

            player.GetComponent<Rigidbody>().useGravity = true;
            player.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * force, ForceMode.Impulse);
            player.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.back * force, ForceMode.Impulse);
            player.transform.parent = null;
            player.transform.localScale = new Vector3(1, 1, 1);
            curHat = null;
        }
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        dead.SetActive(true);
    }

    public void SpeedUp()
    {
        speeduptimer += 10;
    }

    public void Pause()
    {
        gameObject.GetComponent<AudioSource>().Play();
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pause.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pause.SetActive(false);
        }
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
        SceneManager.LoadScene("Main");
    }

    public void Finish()
    {
        PlayerPrefs.SetFloat("record", timer.currentTime);
        Time.timeScale = 0;
        win.SetActive(true);
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
