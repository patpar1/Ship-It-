using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour
{
    public float minWindDelay = 20.0f;
    public float maxWindDelay = 40.0f;
    public float minWindForce = 1.0f;
    public float maxWindForce = 10.0f;
    public float minWindDuration = 2.0f;
    public float maxWindDuration = 10.0f;

    public WindController wind;
    public GameObject audioManager;

    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        StartCoroutine("ApplyWind");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ApplyWind()
    {
        float newWindDelay = Random.Range(minWindDelay, maxWindDelay);
        Debug.Log("Applying wind after " + newWindDelay + " seconds!");

        yield return new WaitForSeconds(newWindDelay);

        bool leftWind = Random.value > 0.5f;
        Vector3 windDirection = leftWind ? Vector3.left : Vector3.right;
        float windForce = Random.Range(minWindForce, maxWindForce);
        float windDuration = Random.Range(minWindDuration, maxWindDuration);

        Debug.Log("Applying wind to direction " + windDirection.x + " with a force of " + windForce + " with a duration of " + windDuration);

        wind.StartWind(leftWind);
        if (wind is DesertWindController)
        {
            yield return new WaitForSeconds(1.0f); // Give the particles time to start playing
        }

        audioManager.GetComponent<AudioManager>().ToggleWindAudio();

        while (windDuration > 0)
        {
            windDuration -= Time.fixedDeltaTime;
            playerRb.AddForce(windDirection * windForce, ForceMode.Force);
            yield return new WaitForFixedUpdate();
        }

        wind.StopWind();
        audioManager.GetComponent<AudioManager>().ToggleWindAudio();

        yield return StartCoroutine("ApplyWind");
    }
}
