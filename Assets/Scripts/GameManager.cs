using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : Singleton<GameManager>
{
    private bool firstUpdate;
    [FormerlySerializedAs("_interactable")] [SerializeField] private XRGrabInteractable _suitCsae;
    [SerializeField] private Animator _startAnimator;
    [SerializeField] private Animator _cabinetOpenAnimator;

    public void PushBook(GameObject book, float force = 2f)
    {
        Rigidbody book_rb = book.GetComponent<Rigidbody>();
        if(!book_rb)
            Debug.Log("No rigidbody attached to the book");
        Debug.Log($"We are pushing the book, {book.transform.forward * force}");

        book_rb.AddForce(book.transform.forward * force);
    }

    protected override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += OnMainSceneLoaded;
    }

    void OnMainSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Office")
        {
            firstUpdate = true;
        }
    }
    public void Update()
    {
        
        if (firstUpdate)
        {
            _startAnimator.SetTrigger("Start");
            firstUpdate = false;
        }
    }

    public void OnSelectSuitcase(SelectEnterEventArgs args)
    {
        if (args.interactorObject.IsSelecting(_suitCsae))
        {
            _cabinetOpenAnimator.SetTrigger("Open");
        }
    }
}