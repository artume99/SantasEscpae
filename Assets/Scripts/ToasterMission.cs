using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToasterMission : MonoBehaviour
{
    [SerializeField] private List<Toast> toastSockets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool allToastsInPlace = toastSockets.All(toast => toast.IsInPlace());
        if (allToastsInPlace)
        {
            // animation
        }

    }
}
