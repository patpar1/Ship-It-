using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WindController : MonoBehaviour
{
    public GameObject player;

    public abstract void StartWind(bool isLeft);

    public abstract void StopWind();
}
