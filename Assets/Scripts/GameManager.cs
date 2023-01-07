using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;
using Object = UnityEngine.Object;

public class GameManager : Singleton<GameManager>
{
    private bool firstUpdate;
    [SerializeField] private Animator _startAnimator;
    private float gameTimer;
    private float maxTime = 60 * 10; // 10 mins
    [SerializeField] private GameObject player;
    [SerializeField] private Transform room1SpawnPoint;
    [SerializeField] private XRDirectInteractor LeftHand;
    [SerializeField] private XRDirectInteractor RightHand;

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

    public void StartGame()
    {
        player.transform.position = room1SpawnPoint.position;
        LoadScene(Scenes.EscapeRoom);
        StartCoroutine(WaitForSceneLoad((int)Scenes.EscapeRoom));
        AudioManager.Instance.PlaySound(AudioManager.Sounds.MainLoop);
        gameTimer = 0f;
        Invoke("StupidThing", 2);


    }

    public void StupidThing()
    {
        // You might be asking yourself WHYYYY??! and my answer is -> because it fixes a stupid bug i couldnt fix in any other awy.
        
        RightHand.enabled = false;
        RightHand.enabled = true;
        LeftHand.enabled = false;
        LeftHand.enabled = true;
        
    }
    
    IEnumerator WaitForSceneLoad(int sceneNumber)
    {
        while (SceneManager.GetActiveScene().buildIndex != sceneNumber)
        {
            yield return null;
        }
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
        AudioManager.Instance.StopSound(AudioManager.Sounds.MainLoop);
        LoadScene(Scenes.MainMenu);
    }
}