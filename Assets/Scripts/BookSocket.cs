using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookSocket : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor socket;
    public int socketPlaceInShelf;

    public void OnBookPut(SelectEnterEventArgs args)
    {
        Debug.Log("BOOK IN");
        Book book = args.interactableObject.transform.gameObject.GetComponent<Book>();
        if (IsBookInPlace(book))
        {
            // sound
            book.SetInPlace(true);
        }
    }

    public void OnBookTake(SelectExitEventArgs args)
    {
        Book book = args.interactableObject.transform.gameObject.GetComponent<Book>();

        book.SetInPlace(false);
    }

    private bool IsBookInPlace(Book book)
    {
        Debug.Log($"{ book.bookPlaceInShelf} and {socketPlaceInShelf}");
        return book.bookPlaceInShelf == socketPlaceInShelf;
    }
}