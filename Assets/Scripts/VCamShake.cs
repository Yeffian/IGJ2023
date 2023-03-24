using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class VCamShake : MonoBehaviour
{
    public static VCamShake Instance { get; private set; }
    
    private CinemachineVirtualCamera _vcam;
    private float _shakeTimer;

    private void Awake()
    {
        Instance = this;
        _vcam = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if (_shakeTimer > 0)
        {
            _shakeTimer -= Time.deltaTime;

            if (_shakeTimer <= 0.0f)
            {
                var noise = _vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                noise.m_AmplitudeGain = 0.0f;
            }
        }
    }

    public void Shake(float intensity, float time)
    {
        var noise = _vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        noise.m_AmplitudeGain = intensity;
        _shakeTimer = time;
    }
}
