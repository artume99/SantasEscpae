using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    [SerializeField] private StudioEventEmitter _eventEmitter;
    
    public void PlaySound()
    {
        _eventEmitter.enabled = true;
        _eventEmitter.enabled = false;
    }

    public void Update()
    {
        throw new NotImplementedException();
    }
}
