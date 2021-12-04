using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowWindController : WindController
{
    public WindZone wind;

    private Vector3 offset;

    private bool m_leftWindPlaying = false;
    private bool m_rightWindPlaying = false;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z) + offset;
    }

    public override void StartWind(bool isLeft)
    {
        if (isLeft)
        {
            wind.windMain = -15;
            m_leftWindPlaying = true;
        }
        else
        {
            wind.windMain = 15;
            m_rightWindPlaying = true;
        }
    }

    public override void StopWind()
    {
        wind.windMain = 0;

        if (m_leftWindPlaying)
        {
            m_leftWindPlaying = false;
        }
        else if (m_rightWindPlaying)
        {
            m_rightWindPlaying = false;
        }
    }
}
