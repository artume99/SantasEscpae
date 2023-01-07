using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Candle : MonoBehaviour
{
    [SerializeField] private ParticleSystem candleParticleSystem;
    [SerializeField] private StudioEventEmitter _eventEmitter;
    private XRGrabInteractable xrGrab;
    public bool lit;


    void Start()
    {
        xrGrab = GetComponent<XRGrabInteractable>();
        xrGrab.enabled = false;

    }

    

    public void LightCandle()
    {
        candleParticleSystem.Play();
        xrGrab.enabled = true;
        lit = true;
        StartCoroutine(FireSound());
    }

    private IEnumerator FireSound()
    {
        float timer = 0;
        _eventEmitter.enabled = true;
        while (timer <= 1)
        {
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        _eventEmitter.enabled = false;
    }
}
