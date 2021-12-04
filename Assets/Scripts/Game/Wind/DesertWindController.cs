using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertWindController : WindController
{
    public ParticleSystem leftWind;
    public ParticleSystem rightWind;

    private float offsetZ;
    private bool m_leftWindPlaying = false;
    private bool m_rightWindPlaying = false;

    void Start()
    {
        offsetZ = transform.position.z - player.transform.position.z;
    }

    void Update()
    {
        
    }

    public override void StartWind(bool isLeft)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + offsetZ);

        if (isLeft)
        {
            leftWind.Play();
            m_leftWindPlaying = true;
        }
        else
        {
            rightWind.Play();
            m_rightWindPlaying = true;
        }
    }

    public override void StopWind()
    {
        if (m_leftWindPlaying)
        {
            leftWind.Stop();
            m_leftWindPlaying = false;
        }
        else if (m_rightWindPlaying)
        {
            rightWind.Stop();
            m_rightWindPlaying = false;
        }
    }
}
