using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var eventEmitter =  gameObject.transform.parent.gameObject.GetComponent<StudioEventEmitter>();
        if(!eventEmitter)
            return;
        eventEmitter.enabled = true;
        eventEmitter.enabled = false;
    }
}
