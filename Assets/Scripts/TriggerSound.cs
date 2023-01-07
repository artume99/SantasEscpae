using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SoundTrigger"))
        {


            var eventEmitter = other.transform.parent.gameObject.GetComponent<StudioEventEmitter>();
            Debug.Log(eventEmitter);
            if (!eventEmitter)
                return;
            eventEmitter.enabled = true;
            eventEmitter.enabled = false;
        }
    }
}
