using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToastSocket : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor socket;
    public int socketPlaceInToaster;

    public void OnBookPut(SelectEnterEventArgs args)
    {
        Toast toast = args.interactableObject.transform.gameObject.GetComponent<Toast>();
        if (IsToastInPlace(toast))
        {
            // sound
            toast.SetInPlace(true);
        }
    }

    public void OnToastTake(SelectExitEventArgs args)
    {
        Toast toast = args.interactableObject.transform.gameObject.GetComponent<Toast>();

        toast.SetInPlace(false);
    }

    private bool IsToastInPlace(Toast toast)
    {
        return toast.toastPlaceInShelf == socketPlaceInToaster;
    }
}