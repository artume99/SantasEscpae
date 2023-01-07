using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class Apple : MonoBehaviour, IEatable
{
    [SerializeField] private StudioEventEmitter _eventEmitter;
    [SerializeField] private AppleMission mission;
    private bool isPlaying;
    
    public void Eat()
    {
        if (!isPlaying)
        {
            AudioManager.Instance.PlayFmodEventEmitter(gameObject);
            mission.AdvanceMission();
            Destroy(gameObject);
            AudioManager.Instance.PlayOneShotAttach(AudioManager.Sounds.Tasty, gameObject);
        }
        
        
    }

    
}
