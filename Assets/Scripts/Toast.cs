using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toast : MonoBehaviour
{
    private bool inPlace;
    public int toastPlaceInShelf;
    public bool IsInPlace()
    {
        return inPlace;
    }

    public void SetInPlace(bool place)
    {
        inPlace = place;
    }

    // TODO: Add sound to drop
}
