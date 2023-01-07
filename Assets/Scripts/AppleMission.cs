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
        Debug.Log("PUSHED");
        drawer.AddForce(Vector3.back * force);
    }

}

