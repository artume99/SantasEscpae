using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    private bool inPlace;
    public int bookPlaceInShelf;
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
