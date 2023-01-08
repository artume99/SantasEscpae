using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
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
    private float maxTime = 60 * 10f; // 10 mins
    [SerializeField] private GameObject player;
    [SerializeField] private Transform room1SpawnPoint;
    [SerializeField] private Transform roomMainSSpawnPoint;
    [SerializeField] private XRDirectInteractor LeftHand;
    [SerializeField] private XRDirectInteractor RightHand;
    public StudioEventEmitter EventEmitter;

    public enum Scenes
    {
        MAIN,
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
        if (scene.name == "MAIN")
        {
            LoadScene(Scenes.MainMenu);
            Invoke("StupidThing", 2);
        }
    }

    public void LoadScene(Scenes scene)
    {
        SceneManager.LoadScene((int)scene);
    }

    public void StartGame()
    {
        Debug.Log("We are here");
        AudioManager.Instance.GetSoundEventInstance(AudioManager.Sounds.MainLoop).setParameterByName("Intensity", 0);
        player.transform.position = room1SpawnPoint.position;
        LoadScene(Scenes.EscapeRoom);
        StartCoroutine(WaitForSceneLoad((int)Scenes.EscapeRoom));
        AudioManager.Instance.PlaySound(AudioManager.Sounds.MainLoop);
        gameTimer = 0f;
        Invoke("StupidThing", 2);
        TeleportManager.Instance.ActivateTeleportation(true);



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
        int intensity = (int)Mathf.Lerp(0, 100, gameTimer / maxTime);
        AudioManager.Instance.GetSoundEventInstance(AudioManager.Sounds.MainLoop).setParameterByName("Intensity", intensity);
        if (gameTimer > maxTime)
        {
            AudioManager.Instance.PlaySound(AudioManager.Sounds.Fail);
            Restart();
            gameTimer = 0;
        }
    }

    public void Restart()
    {
        TeleportManager.Instance.ActivateTeleportation(false);
        AudioManager.Instance.StopSound(AudioManager.Sounds.MainLoop);
        player.transform.position = roomMainSSpawnPoint.position;
        LoadScene(Scenes.MainMenu);
    }

    public void Win()
    {
        AudioManager.Instance.PlaySound(AudioManager.Sounds.Win);
    }
}