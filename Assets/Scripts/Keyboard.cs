using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    private float time = 0f;
    private float timeToCompleteMission = 5f;
    public bool activated;
    [SerializeField] private StudioEventEmitter _eventEmitter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            _eventEmitter.enabled = true;
            activated = true;
            time = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _eventEmitter.enabled = false;
    }

    public void Update()
    {
        if (activated)
        {
            time += Time.deltaTime;
            if (time > timeToCompleteMission)
            {
                time = 0f;
                activated = false;
            }
        }
    }
}
