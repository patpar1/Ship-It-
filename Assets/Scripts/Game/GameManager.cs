using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject audioManager;
    public GameObject wonText;

    public float winZ;
    public float lostTime = 8.0f;

    public static bool hasWon;
    public static bool hasLost;

    // Start is called before the first frame update
    void Start()
    {
        hasWon = false;
        hasLost = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasWon && !hasLost)
        {
            if (player.transform.position.z > winZ && !hasWon)
            {
                Debug.Log("You Won!");
                hasWon = true;
                audioManager.GetComponent<AudioManager>().PlayWinAudio();
                StartCoroutine("ReturnToMenu");
            }

            if (player.GetComponent<PlayerController>().timeOnCollision > lostTime)
            {
                Debug.Log("You Lost!");
                hasLost = true;
                audioManager.GetComponent<AudioManager>().PlayLoseAudio();
                StartCoroutine("RestartLevel");
            }
        }
    }

    IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(5);
        wonText.SetActive(false);
        SceneManager.LoadScene(0);
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
