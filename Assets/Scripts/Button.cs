using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool activated;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            AudioManager.Instance.PlayOneShotAttach(AudioManager.Sounds.Button, gameObject);
            activated = true;
        }
    }
}
