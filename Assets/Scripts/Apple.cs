using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour, IEatable
{
    [SerializeField] private AppleMission mission;
    public void Eat()
    {
        // todo: Apple sound
        mission.AdvanceMission();
        Destroy(gameObject);
        
    }

    
}
