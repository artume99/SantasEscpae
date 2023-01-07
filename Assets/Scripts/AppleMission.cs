using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleMission : MonoBehaviour
{
    [SerializeField] private Rigidbody drawer;
    [SerializeField] private Sprite[] appleSprites;
    [SerializeField] private Image imageToShow;
    public float force;
    private bool completed;
    private int applesEaten = 0;

    private void Start()
    {
        drawer.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    public void AdvanceMission()
    {
        if(completed)
            return;
        applesEaten += 1;
        imageToShow.sprite = appleSprites[applesEaten];
        if (applesEaten == appleSprites.Length - 1)
        {
            PushDrawer();
            completed = true;
        }

    }

    private void PushDrawer()
    {
        drawer.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        AudioManager.Instance.PlayOneShotAttach(AudioManager.Sounds.DrawerOpen, drawer.gameObject);
        drawer.AddForce(Vector3.back * force);
        
    }

}

