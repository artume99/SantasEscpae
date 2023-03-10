using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FMODUnity;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToasterMission : MonoBehaviour
{
    [SerializeField] private List<ToastSocket> toasts;
    [SerializeField] private Transform toastsHolder;
    [SerializeField] private Transform toastEnter;
    [SerializeField] private GameObject toaster;
    [SerializeField] private ParticleSystem candleParticleSystem;
    [SerializeField] private Candle candle;
    private Vector3 origPos;
    private bool missionCompleted;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        origPos = toastsHolder.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!missionCompleted)
        {
            bool allToastsInPlace = toasts.All(toast => toast.IsOccupied);
            if (allToastsInPlace)
            {
                StartCoroutine(EnterToastsToToaster());
                missionCompleted = true;
            }
        }
    }

    private IEnumerator EnterToastsToToaster()
    {
        while (Math.Abs(toastsHolder.position.y - toastEnter.position.y) > 0.05)
        {
            Debug.Log(toastsHolder.position.y - toastEnter.position.y);
            timer += Time.deltaTime / 2f;
            toastsHolder.position = Vector3.Lerp(origPos, toastEnter.position, timer);
            yield return new WaitForFixedUpdate();
        }

        toaster.GetComponent<Highlight>().ToggleHighlight(true);
        timer = 0;
        while (timer < 10)
        {
            toaster.GetComponent<Highlight>().ToggleHighlight(true);
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        
        candle.LightCandle();
        while (Math.Abs(toastsHolder.position.y - origPos.y) > 0.05)
        {
            Debug.Log(toastsHolder.position.y - toastEnter.position.y);
            timer += Time.deltaTime * 4f;
            toastsHolder.position = Vector3.Lerp(toastEnter.position, origPos, timer);
            yield return new WaitForFixedUpdate();
        }
        AudioManager.Instance.PlayOneShotAttach(AudioManager.Sounds.ToastReady, gameObject);
    }
    
}