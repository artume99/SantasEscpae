using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleMission : MonoBehaviour
{
    public GameObject apple;
    public GameObject fridge;
    public Transform drawerT;
    public int indc = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (apple.transform.position.x < fridge.transform.position.x)
        {
            indc = 1;
        }
        Vector3 drawer = Vector3.Lerp(drawerT.position, drawerT.position + Vector3.up, indc);

    }

}

