using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class TriggerFire : MonoBehaviour
{
    [SerializeField] private ParticleSystem fire;
    [SerializeField] private StudioEventEmitter _eventEmitter;
    private void OnTriggerEnter(Collider other)
    {
        var candle = other.gameObject.GetComponent<Candle>();
        bool isCandle = candle is not null;
        if (isCandle && candle.lit)
        {
            PlayFire();
        }
    }

    public void PlayFire()
    {
        _eventEmitter.enabled = true;
        fire.Play();
    }
}
