using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToastSocket : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor socket;
    public bool IsOccupied;

    public void OnToastPut(SelectEnterEventArgs args)
    {
        Toast toast = args.interactableObject.transform.gameObject.GetComponent<Toast>();
        IsOccupied = true;
        toast.SetInPlace(true);
    }

    public void OnToastTake(SelectExitEventArgs args)
    {
        Toast toast = args.interactableObject.transform.gameObject.GetComponent<Toast>();
        IsOccupied = false;

        toast.SetInPlace(false);
    }

  
}