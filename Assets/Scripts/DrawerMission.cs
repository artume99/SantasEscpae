using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerMission : MonoBehaviour
{
    public GameObject drawer;
    private Rigidbody drawerRb;

    public Keyboard keyboard;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        drawerRb = drawer.GetComponent<Rigidbody>();
        drawerRb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void Update()
    {
        if (button.activated && keyboard.activated)
        {
            Debug.Log("OPEN");
            drawerRb.constraints &= ~RigidbodyConstraints.FreezePositionZ;
        }
    }
}