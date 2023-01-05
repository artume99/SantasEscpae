using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    private float time = 0f;
    private float timeToCompleteMission = 5f;
    public bool activated;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Debug.Log("*KEYBOARD SOUNDS*");
            activated = true;
        }
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
