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
    [SerializeField] private Animator _startAnimator;

    public enum Scenes
    {
        MainMenu,
        EscapeRoom,
        Final
    }
    
    protected override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += OnMainSceneLoaded;
    }
    void Start()
    {
      

    }
    void OnMainSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Office")
        {
            firstUpdate = true;
        }
    }

    public void LoadScene(Scenes scene)
    {
        SceneManager.LoadScene((int)scene);
    }

}