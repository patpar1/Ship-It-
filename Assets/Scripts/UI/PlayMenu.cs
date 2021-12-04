using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    public void PlayDesert()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayForest()
    {
        SceneManager.LoadScene(2);
    }

}
