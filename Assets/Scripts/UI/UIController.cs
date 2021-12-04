using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class UIController : MonoBehaviour
{
    public Slider slider;
    
    public TextMeshProUGUI currentTime;
    public TextMeshProUGUI bestTime;
    public TextMeshProUGUI secondsToLost;
    public GameObject wonText;
    public GameObject player;

    public bool isWinter;

    public float timeToLost = 8.0f;

    private float m_timer = 0.0f;
    private float m_bestTime;

    private bool gameEndStateUpdated = false;

    // Start is called before the first frame update
    void Start()
    {
        m_bestTime = GetPB();
        bestTime.text = "PB: " + GetStringTime(m_bestTime);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = player.transform.position.z;

        if (!GameManager.hasWon && !GameManager.hasLost)
        {
            m_timer += Time.deltaTime;
            currentTime.text = GetStringTime(m_timer);
            if (player.GetComponent<PlayerController>().timeOnCollision <= timeToLost - 3)
            {
                secondsToLost.text = "";
            }
            else if (player.GetComponent<PlayerController>().timeOnCollision > timeToLost - 1)
            {
                secondsToLost.text = "1";
            }
            else if (player.GetComponent<PlayerController>().timeOnCollision > timeToLost - 2)
            {
                secondsToLost.text = "2";
            }
            else if (player.GetComponent<PlayerController>().timeOnCollision > timeToLost - 3)
            {
                secondsToLost.text = "3";
            }
        }
        else if (GameManager.hasWon && !gameEndStateUpdated)
        {
            wonText.SetActive(true);
            if (m_bestTime == 0 || m_timer < m_bestTime)
            {
                SetPB(m_timer);
                m_bestTime = GetPB();
                bestTime.text = "PB: " + GetStringTime(m_bestTime);
            }
            gameEndStateUpdated = true;
        }
        else if (GameManager.hasLost && !gameEndStateUpdated)
        {
            secondsToLost.text = "You Lost!";
            gameEndStateUpdated = true;
        }
    }

    string GetStringTime(float time)
    {
        float minutes = Mathf.Floor(time / 60);
        float seconds = Mathf.Floor(time) % 60;
        float milliseconds = Mathf.Floor((time * 100) % 100);
        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    void SetPB(float time)
    {
        if (isWinter)
        {
            PlayerPrefs.SetFloat("bestTimeWinter", time);
        }
        else
        {
            PlayerPrefs.SetFloat("bestTimeDesert", time);
        }
    }

    float GetPB()
    {
        if (isWinter)
        {
            return PlayerPrefs.GetFloat("bestTimeWinter", 0);
        }
        else
        {
            return PlayerPrefs.GetFloat("bestTimeDesert", 0);
        }
    }
}
