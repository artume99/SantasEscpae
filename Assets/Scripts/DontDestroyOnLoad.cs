using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class DontDestroyOnLoad : MonoBehaviour
{
    public string ObjectId;

    private void Awake()
    {
        ObjectId = name + transform.position.ToString() + transform.eulerAngles.ToString();
    }

    private void Start()
    {
       DontDestroyOnLoad(gameObject);
    }
}
