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
    private float gameTimer;
    private float maxTime = 60 * 10; // 10 mins

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
        AudioManager.Instance.PlaySound(AudioManager.Sounds.ClockTicking);

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

    private void Update()
    {
        gameTimer += Time.deltaTime;
        if (gameTimer > maxTime)
        {
            Restart();
        }
    }

    public void Restart()
    {
        LoadScene(Scenes.MainMenu);
    }
}