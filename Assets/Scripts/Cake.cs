using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class Cake : MonoBehaviour, IEatable
{
    [SerializeField] private StudioEventEmitter _eventEmitter;
    private bool isPlaying;
    public void Eat()
    {
        if (!isPlaying)
        {
            _eventEmitter.Play();
            Destroy(gameObject);
            
        }
       
    }
    
    
    
}
