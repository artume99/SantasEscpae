using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookMission : MonoBehaviour
{
    [SerializeField] private List<Book> bookSockets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool allBooksInPlace = bookSockets.All(book => book.IsInPlace());
        if (allBooksInPlace)
        {
            // animation
        }
    }
}
