using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }

    private CinemachineVirtualCamera m_Cinemachine;
    private float shakeTimer;
    private float shakeTimerTotal;
    private float startingIntensity;

    private void Awake()
    {
        Instance = this;
        m_Cinemachine = GetComponent<CinemachineVirtualCamera>();
        m_Cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin basicMultiChannelPerlin =
            m_Cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        if (intensity > basicMultiChannelPerlin.m_AmplitudeGain)
        {
            startingIntensity = intensity;
            shakeTimer = time;
            shakeTimerTotal = time;
        }
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            CinemachineBasicMultiChannelPerlin basicMultiChannelPerlin =
                m_Cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            basicMultiChannelPerlin.m_AmplitudeGain =
                Mathf.Lerp(startingIntensity, 0f, 1 - (shakeTimer / shakeTimerTotal));
        }
    }
}